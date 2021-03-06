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