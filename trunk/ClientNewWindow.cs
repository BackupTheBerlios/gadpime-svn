using System;
using System.Data;

namespace gadpime
{	
	public partial class ClientNewWindow : Gtk.Window
	{
		private IDbConnection dbcon;
		private Boolean changed;
		private Boolean newClient;
		
		public ClientNewWindow(IDbConnection con) : base(Gtk.WindowType.Toplevel)
		{
			dbcon=con;
			changed=false;
			newClient=true;
			this.Build();
		}

		protected virtual void Close (object sender, System.EventArgs e)
		{
			this.Destroy();
		}

		protected virtual void ClientSave (object sender, System.EventArgs e)
		{
			try {
				if (newClient) {
					string sql = "INSERT INTO clients (name,surname1,surname2) VALUES ("+
						"'"+this.EntryClientName.Text+"',"+
						"'"+this.EntryClientSurname1.Text+"',"+
						"'"+this.EntryClientSurname2.Text+"'"+
						")";
					IDbCommand dbcmd = dbcon.CreateCommand();
					dbcmd.CommandText = sql;
					IDataReader reader=dbcmd.ExecuteReader();
					reader.Close();
					Console.WriteLine("New client saved");
					newClient=false;
					this.ButtonClientSave.Visible=false;
				} else if (changed) {
					// guardar canvis
				}
				} catch (Exception ex) {
				Console.WriteLine("ClientSave: "+ex.Message);
			}
		}

		protected virtual void ClientDataChanged (object sender, System.EventArgs e)
		{
			changed=true;
		}
	}
}
