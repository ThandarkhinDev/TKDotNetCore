using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using TKDotNetCore.RestApi.Db;
using TKDotNetCore.RestApi.Models;

namespace TKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context= new AppDbContext();
        /*public BlogController()
        {
            _context = new AppDbContext();
        }*/

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetDataById(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x=> x.BlogId == id);
            if (item == null) return NotFound($"No Data found for this id {id}");
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result = _context.SaveChanges();
            string message = result > 0 ? "Successfully Saved." : "Fail to save Data";

            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null) return NotFound($"No Data found for this id {id}");
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            int result = _context.SaveChanges();

            string message = result > 0 ? "Successfully Updated." : "Fail to update Data";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null) return NotFound($"No Data found for this id {id}");
            if (!string.IsNullOrEmpty(blog.BlogTitle)) item.BlogTitle = blog.BlogTitle;
            if (!string.IsNullOrEmpty(blog.BlogAuthor)) item.BlogAuthor = blog.BlogAuthor;
            if (!string.IsNullOrEmpty(blog.BlogContent)) item.BlogContent = blog.BlogContent;

            int result = _context.SaveChanges();

            string message = result > 0 ? "Successfully Updated." : "Fail to update Data";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null) return NotFound($"No Data found for this id {id}");
            _context.Blogs.Remove(item);
            int result = _context.SaveChanges();
            string message = result > 0 ? "Successfully Deleted." : "Fail to delete Data";
            return Ok(message);
        }
    }
}
