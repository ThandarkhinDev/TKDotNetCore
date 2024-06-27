using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKDotNetCore.ConsoleApp
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            //Read();
            GetDataById(5);
            GetDataById(8);
        }
        private void Read()
        {
            var lst = db.Blogs.ToList();

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
            var blogItem = db.Blogs.FirstOrDefault(x => x.BlogId == blogid);
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
