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
            Read();

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
    }
    
}
