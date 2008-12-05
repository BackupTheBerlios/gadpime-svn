using System;
using System.Data;
using System.Collections;
using Gtk;

namespace gadpime
{	
	public partial class ClientWindow : Gtk.Window
	{
		private IDbConnection dbcon;
		private Boolean changed;
		private SortedList clientList;
		private int index;
		private Client client;
		
		public ClientWindow(IDbConnection con, SortedList l) : base(Gtk.WindowType.Toplevel)
		{
			dbcon=con;
			changed=false;
			clientList=l;
			this.Build();
			index=0;
			this.GetValue(index);
		}
		
		private void GetValue(int i) {
			client=(Client)clientList.GetByIndex(i);
			this.EntryClientName.Text=client.name;
			this.EntryClientSurname1.Text=client.surname1;
			this.EntryClientSurname2.Text=client.surname2;
			changed=false;
		}

		private void SetValue(int i) {
			client=(Client)clientList.GetByIndex(i);
			client.name=this.EntryClientName.Text;
			client.surname1=this.EntryClientSurname1.Text;
			client.surname2=this.EntryClientSurname2.Text;
			changed=false;
		}
		
		protected virtual void Close (object sender, System.EventArgs e)
		{
			this.Destroy();
		}

		protected virtual void ClientSave (object sender, System.EventArgs e)
		{
			try {
					this.SetValue(index);
					string sql="UPDATE clients SET "+ 
						"name = '"+this.EntryClientName.Text+"',"+ 
						"surname1 = '"+this.EntryClientSurname1.Text+"',"+
						"surname2 = '"+this.EntryClientSurname2.Text+"' "+
						"WHERE id="+client.id; 
					IDbCommand dbcmd = dbcon.CreateCommand();
					dbcmd.CommandText = sql;
					IDataReader reader=dbcmd.ExecuteReader();
					reader.Close();
					Console.WriteLine("New client saved");
	
				} catch (Exception ex) {
				Console.WriteLine("ClientSave: "+ex.Message);
			}
		}

		protected virtual void ClientDataChanged (object sender, System.EventArgs e)
		{
			changed=true;
		}

		private bool AskSave() {
			bool answer=true;
			ResponseType rsp;
			if (changed) {
				MessageDialog msgBox=new MessageDialog(this,DialogFlags.Modal,Gtk.MessageType.Question,ButtonsType.YesNo,"Hay cambios sin guardar, quieres guardarlos?");
				rsp=(ResponseType)msgBox.Run();
				if (rsp==ResponseType.Yes) {
					ClientSave(this,System.EventArgs.Empty);
				} else if (rsp==ResponseType.No) {
					
				} else {
					answer=false;
				}
				msgBox.Destroy();
			}
			return answer;
			
		}
		protected virtual void ClientBack (object sender, System.EventArgs e)
		{
			if (AskSave()) {
				if (index>0) {
					this.GetValue(--index);
				}
			}
			
		}

		protected virtual void ClientForward (object sender, System.EventArgs e)
		{
			if (AskSave()) {
				if (index<(clientList.Count-1)) {
					this.GetValue(++index);
				}
			}
		}

	
		protected virtual void ClientDelete (object sender, System.EventArgs e)
		{
			// delete current client from list and from db
	
			try {
				this.SetValue(index);
				string sql="DELETE FROM clients WHERE id="+client.id; 
				IDbCommand dbcmd = dbcon.CreateCommand();
				dbcmd.CommandText = sql;
				IDataReader reader=dbcmd.ExecuteReader();
				reader.Close();
				Console.WriteLine("Client deleted");
				clientList.RemoveAt(index);
				// if last client from list destroy window
				// else reload data
				if (clientList.Count==0) {
					this.Destroy();
				} else {
					this.GetValue(index);
				}

			} catch (Exception ex) {
				Console.WriteLine("ClientDelete: "+ex.Message);
			}
		}

	}
}
