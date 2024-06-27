using Dapper;
using Microsoft.EntityFrameworkCore;
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
            //GetDataById(5);
            //GetDataById(8);
            //Create("Title8", "Author8", "Content8");
            //Update(7, "Title6", "Author6", "Content6");
            Delete(5);
            Delete(11);
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

        private void Create(string title, string author, string content)
        {
            var blogItem = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(blogItem);
            int result = db.SaveChanges();
            string message = result > 0 ? "Successfully Saved." : "Fail to save Data";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var blogItem = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blogItem is null)
            {
                Console.WriteLine("No Data Found for this ID: " + id);
                return;
            }
            blogItem.BlogTitle = title;
            blogItem.BlogAuthor = author;
            blogItem.BlogContent = content; 
            
            int result = db.SaveChanges();

            string message = result > 0 ? "Successfully Updated." : "Fail to update Data";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var blogItem = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blogItem is null)
            {
                Console.WriteLine("No Data Found for this ID: " + id);
                return;
            }
            db.Blogs.Remove(blogItem);
            var result = db.SaveChanges();

            string message = result > 0 ? "Successfully Deleted." : "Fail to delete Data";
            Console.WriteLine(message);
        }
    }
}
