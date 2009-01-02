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
using Gtk;
using System.Data;

namespace gadpime
	{
	public partial class MainWindow: Gtk.Window
	{	
		public IDbConnection dbcon;
		
		public MainWindow (IDbConnection con): base (Gtk.WindowType.Toplevel)
		{
			dbcon=con;			
			Build ();
		}

		
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		protected virtual void Quit (object sender, System.EventArgs e)
		{
			Application.Quit ();
		}

		protected virtual void ClientNew (object sender, System.EventArgs e)
		{
			try {
				ClientNewWindow cw = new ClientNewWindow (dbcon);
				cw.Show ();
			} catch (Exception ex) {
				Console.WriteLine("ClientNew: "+ex.Message);
			}
		}

		protected virtual void ClientSearch (object sender, System.EventArgs e)
		{
			try {
				ClientSearchWindow csw = new ClientSearchWindow (dbcon);
				csw.Show ();
			} catch (Exception ex) {
				Console.WriteLine("ClientSearch: "+ex.Message);
			}
		}

		protected virtual void About (object sender, System.EventArgs e)
		{
			try {
				AboutWindow cw = new AboutWindow ();
				cw.Show ();
			} catch (Exception ex) {
				Console.WriteLine("About: "+ex.Message);
			}
		}

	}
}