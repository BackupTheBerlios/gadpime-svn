using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

public class Form1 : Form
{
	private DataGridView dgv;
	private BindingSource bs;
	
	public static void Main() {
		Application.EnableVisualStyles();
		Application.Run(new Form1());
	}

	public Form1() {
		this.AutoSize = true;
		dgv = new DataGridView();
		bs= new BindingSource();
		dgv.Dock=DockStyle.Fill;
		
		dgv.Size = new Size(500,50);
		dgv.Location = new Point(5,10);
		dgv.RowTemplate = new DataGridViewRow();
		
		DataGridViewColumn col = new DataGridViewColumn();
		col.CellTemplate = new DataGridViewTextBoxCell();
		dgv.Columns.Add(col.Clone() as DataGridViewColumn);
		dgv.Columns.Add(col.Clone() as DataGridViewColumn);
	
		string connectionString ="Server=localhost;Database=prova;User ID=gadpime;Password=gadpime;Pooling=false";
    string sql ="SELECT * FROM clients";
		
		MySqlConnection mysqlCon = new MySqlConnection(connectionString);
		mysqlCon.Open();

		MySqlDataAdapter MyDA = new MySqlDataAdapter();
		MyDA.SelectCommand = new MySqlCommand(sql, mysqlCon);

		DataTable table = new DataTable();
		MyDA.Fill(table);
		
		bs.DataSource=table;

		dgv.DataSource=bs;

		Console.WriteLine(bs.Count);
		Console.WriteLine(table.Rows[2].ItemArray[1]);

		
		this.Controls.Add(dgv);
		this.Text = "datagrid";
	}
}

