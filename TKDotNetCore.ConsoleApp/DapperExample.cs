using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //GetDataById(5);
            //GetDataById(6);
            //Create("Title9", "Author9", "Content9");
            //Update(6, "Title6a", "Author6a", "Content6a");
            Delete(10);

        }
        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList();

            foreach (BlogDto blog in lst)
            {
                Console.WriteLine("BlogId : " + blog.BlogId);
                Console.WriteLine("BlogTitle : " + blog.BlogTitle);
                Console.WriteLine("BlogAuthor : " + blog.BlogAuthor);
                Console.WriteLine("BlogContent : " + blog.BlogContent);
                Console.WriteLine("--------------");
            }
        }

        private void GetDataById(int blogid)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var blogItem = db.Query<BlogDto>("Select * from tbl_blog where BlogID = @BlogId",  new BlogDto { BlogId = blogid}).FirstOrDefault();

            if (blogItem is null)
            {
                Console.WriteLine("No Data Found for this ID: " + blogid);
                return;
            }

            Console.WriteLine("BlogId : " + blogItem.BlogId);
            Console.WriteLine("BlogTitle : " + blogItem.BlogTitle);
            Console.WriteLine("BlogAuthor : " + blogItem.BlogAuthor);
            Console.WriteLine("BlogContent : " + blogItem.BlogContent);
            Console.WriteLine("--------------");
        }

        private void Create(string title, string author, string content)
        {

            var blogItem = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                 ([blogtitle], [blogauthor], [blogcontent])
                                 VALUES
                                 (@BlogTitle, @BlogAuthor, @BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, blogItem);

            string message = result > 0 ? "Successfully Saved." : "Fail to save Data";
            Console.WriteLine(message);
        }
        private void Update(int id, string title, string author, string content)
        {

            var blogItem = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"UPDATE [dbo].[Tbl_Blog]
                                 SET [BlogTitle] = @BlogTitle,
                                     [BlogAuthor] = @BlogAuthor,
                                     [BlogContent] = @BlogContent
                                 WHERE [BlogId] = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, blogItem);

            string message = result > 0 ? "Successfully Updated." : "Fail to update Data";
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {

            var blogItem = new BlogDto
            {
                BlogId = id
            };
            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId= @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, blogItem);

            string message = result > 0 ? "Successfully Deleted." : "Fail to delete Data";
            Console.WriteLine(message);
        }
    }
    
}
