using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "TKDotNetCore",
            UserID = "sa",
            Password = "sasasi123"
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            //SqlConnection connection1 = new SqlConnection("Data Source=.;Initial Catalog=TKDotNetCore;User ID=sa;Password=sasasi123");

            connection.Open();
            Console.WriteLine("Connection Open");

            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection Close");

            foreach (DataRow dr in dt.Rows)
            {
                /*Console.WriteLine("BlogId : " + dr["BlogId"]);
                Console.WriteLine("BlogId : " + dr["BlogTitle"]);
                Console.WriteLine("BlogId : " + dr["BlogAuthor"]);
                Console.WriteLine("BlogId : " + dr["BlogContent"]);*/
                Console.WriteLine(dr[0].ToString());
                Console.WriteLine(dr[1].ToString());
                Console.WriteLine(dr[2].ToString());
                Console.WriteLine(dr[3].ToString());
                Console.WriteLine("--------------");
            }

        }

        public void Create(string Title, string Author, string Content)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            /*SqlCommand cmd = "INSERT INTO[dbo].[Tbl_Blog] ([BlogTitle] , [BlogAuthor] , [BlogContent])  VALUES (< BlogTitle, varchar(50),> ,< BlogAuthor, varchar(50),> ,< BlogContent, varchar(50),>)"*/

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", Title);
            cmd.Parameters.AddWithValue("@BlogAuthor", Author);
            cmd.Parameters.AddWithValue("@BlogContent", Content);
            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "Successfully Saved.": "Fail to save Data";
            Console.WriteLine(message);

        }
    }
}
