

using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;

namespace gadpime
{
	class MainClass
	{

		public static void Main (string[] args)
		{

			/** open mysql connection **/
			string connectionString="Server=localhost;Database=gadpime;User ID=gadpime;Password=gadpime;Pooling=false";
      IDbConnection dbcon;
      dbcon = new MySqlConnection(connectionString);
      dbcon.Open();

      /****/
			Application.Init ();
			MainWindow win = new MainWindow (dbcon);
			win.Show ();
			Application.Run ();
						
			/** close mysql connection **/
      dbcon.Close();
      dbcon = null;
			/****/
			

		}
	}
}