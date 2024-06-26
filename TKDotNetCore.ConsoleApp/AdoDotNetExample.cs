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
            using (SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
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
        }

        public void Create(string Title, string Author, string Content)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();

                string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                 ([BlogTitle], [BlogAuthor], [BlogContent])
                                 VALUES
                                 (@BlogTitle, @BlogAuthor, @BlogContent)";

                SqlCommand cmd = new SqlCommand(query, sqlConnection)
                {
                    Parameters =
                    {
                        new SqlParameter("@BlogTitle", Title),
                        new SqlParameter("@BlogAuthor", Author),
                        new SqlParameter("@BlogContent", Content)
                    }
                };
                int result = cmd.ExecuteNonQuery();

                sqlConnection.Close();

                string message = result > 0 ? "Successfully Saved." : "Fail to save Data";
                Console.WriteLine(message);
            }
        }

        public void Update(int ID, string Title, string Author, string Content)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();

                string query = @"UPDATE [dbo].[Tbl_Blog]
                                 SET [BlogTitle] = @BlogTitle,
                                     [BlogAuthor] = @BlogAuthor,
                                     [BlogContent] = @BlogContent
                                 WHERE [BlogId] = @BlogId";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@BlogId", ID);
                cmd.Parameters.AddWithValue("@BlogTitle", Title);
                cmd.Parameters.AddWithValue("@BlogAuthor", Author);
                cmd.Parameters.AddWithValue("@BlogContent", Content);
                int result = cmd.ExecuteNonQuery();

                sqlConnection.Close();

                string message = result > 0 ? "Successfully Updated." : "Fail to Update Data";
                Console.WriteLine(message);
            }
        }

        public void Delete(int blogid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();

                string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId= @BlogId";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@BlogId", blogid);
                int result = cmd.ExecuteNonQuery();

                sqlConnection.Close();

                string message = result > 0 ? "Successfully Deleted." : "Fail to Delete Data";
                Console.WriteLine(message);
            }
        }

        public void GetDataById(int blogid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();

                string query = @"SELECT * FROM [dbo].[Tbl_Blog] WHERE BlogId= @BlogId";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@BlogId", blogid);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                sqlConnection.Close();
                Console.WriteLine("Connection Close");

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No Data Found for this ID: " + blogid);
                    return;
                }

                DataRow dr = dt.Rows[0];

                Console.WriteLine("Blog Id: " + dr[0].ToString());
                Console.WriteLine("Blog title: " + dr[1].ToString());
                Console.WriteLine("Blog author: " + dr[2].ToString());
                Console.WriteLine("Blog content: " + dr[3].ToString());
            }
        }
    }
}
