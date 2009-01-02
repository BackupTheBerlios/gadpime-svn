// About.cs
// 
// Copyright (C) 2009 Oscar Lopez
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

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
