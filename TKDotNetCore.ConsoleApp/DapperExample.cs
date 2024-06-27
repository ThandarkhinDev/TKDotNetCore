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
            GetDataById(5);
            GetDataById(6);

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
    }
    
}
