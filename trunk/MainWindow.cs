
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
	}
}