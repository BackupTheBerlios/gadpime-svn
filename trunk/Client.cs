// Client.cs
// 
// Copyright (C) 2008 [name of author]
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

namespace gadpime
{
	public class Client
	{	
		private int i;
		private string n;
		private string s1;
		private string s2;
		
		public Client(int i, string n, string s1, string s2) {
			this.i=i;
			this.n=n;
			this.s1=s1;
			this.s2=s2;
		}
		
		public string name { get {return this.n; } set { this.n=value;} }
		public string surname1 { get {return this.s1; } set { this.s1=value;} }
		public string surname2 { get {return this.s2; } set { this.s2=value;} }
		public int id { get {return this.i; } set { this.i=value;} }		
		
		public string nomComplet() { return s1+s2+n; }
		
	}
}