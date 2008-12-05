using System;
using System.Data;
using System.Collections;

namespace gadpime
{	
	public partial class ClientSearchWindow : Gtk.Window
	{
		private SortedList searchResult;
		private IDbConnection dbcon;
		private IDataReader reader;
		public ClientSearchWindow(IDbConnection con) : base(Gtk.WindowType.Toplevel)
		{
			searchResult=new SortedList();
			dbcon=con;
			this.Build();
		}

		protected virtual void Close (object sender, System.EventArgs e)
		{
			this.Destroy();
		}

		protected virtual void ClientSearch (object sender, System.EventArgs e)
		{
			try {
				string sql = "SELECT * FROM clients WHERE id>=0 ";
				if (this.EntryClientName.Text!="") sql+=" AND name='"+this.EntryClientName.Text+"'";
				if (this.EntryClientSurname1.Text!="") sql+=" AND surname1='"+this.EntryClientSurname1.Text+"'";
				if (this.EntryClientSurname2.Text!="") sql+=" AND surname2='"+this.EntryClientSurname2.Text+"'";
				Console.WriteLine(sql);
				IDbCommand dbcmd = dbcon.CreateCommand();
				dbcmd.CommandText = sql;
				reader = dbcmd.ExecuteReader();
				Client client;
				int i=0;
				while(reader.Read()) {
					client=new Client((int)reader["id"],(string)reader["name"],(string)reader["surname1"],(string)reader["surname2"]);
					searchResult.Add(i++,client);
					Console.WriteLine(client.nomComplet());
				}
				if (i>0) {
					Console.WriteLine("Client finded");
					ClientWindow cw = new ClientWindow (dbcon,searchResult);
					cw.Show ();
					Console.WriteLine("Client finded 2");
					this.Destroy();
				}
				reader.Close();
				

				} catch (Exception ex) {
				Console.WriteLine("ClientSearch: "+ex.Message);
				reader.Close();
			}
		}

		protected virtual void Quit (object sender, System.EventArgs e)
		{
		}

	}
}
