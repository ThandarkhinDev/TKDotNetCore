// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = ".";
stringBuilder.InitialCatalog = "TKDotNetCore";
stringBuilder.UserID = "sa";
stringBuilder.Password= "sasasi123";

SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

//SqlConnection connection1 = new SqlConnection("Data Source=.;Initial Catalog=TKDotNetCore;User ID=sa;Password=sasasi123");

connection.Open();
Console.WriteLine("Connection Open");

string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt= new DataTable();
sqlDataAdapter.Fill(dt);

connection.Close();
Console.WriteLine("Connection Close");

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("BlogId : "+ dr["BlogId"]);
    Console.WriteLine("BlogId : " + dr["BlogTitle"]);
    Console.WriteLine("BlogId : " + dr["BlogAuthor"]);
}

Console.ReadKey();
