using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using TKDotNetCore.RestApi.Models;

namespace TKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult Read()
        {
            string query = "select * from tbl_blog";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetDataById(int id)
        {
            var blogItem = FindById(id);
            if (blogItem is null) return NotFound("No Data Found for this ID: " + id);
            return Ok(blogItem);
        }
        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                 ([blogtitle], [blogauthor], [blogcontent])
                                 VALUES
                                 (@BlogTitle, @BlogAuthor, @BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, blog);
            string message = result > 0 ? "Successfully Saved." : "Fail to save Data";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var blogItem = FindById(id);
            if (blogItem is null) return NotFound("No Data Found for this ID: " + id);
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
                                 SET [BlogTitle] = @BlogTitle,
                                     [BlogAuthor] = @BlogAuthor,
                                     [BlogContent] = @BlogContent
                                 WHERE [BlogId] = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, blog);

            string message = result > 0 ? "Successfully Updated." : "Fail to update Data";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var blogItem = FindById(id);
            if (blogItem is null) return NotFound("No Data Found for this ID: " + id);
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle)) conditions += "[BlogTitle] = @BlogTitle,";
            if (!string.IsNullOrEmpty(blog.BlogAuthor)) conditions += "[BlogAuthor] = @BlogAuthor,";
            if (!string.IsNullOrEmpty(blog.BlogContent)) conditions += "[BlogContent] = @BlogContent,";
            if (conditions.Length == 0) return NotFound("No Data To Be update");
            conditions = conditions.TrimEnd(',');
            blog.BlogId = id;
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                                 SET {conditions}
                                 WHERE [BlogId] = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, blog);

            string message = result > 0 ? "Successfully Updated." : "Fail to update Data";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var blogItem = FindById(id);
            if (blogItem is null) return NotFound("No Data Found for this ID: " + id);
            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId= @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, blogItem);
            string message = result > 0 ? "Successfully Deleted." : "Fail to delete Data";
            return Ok(message);
        }
        private BlogModel? FindById(int id)
        {
            string query = "Select * from tbl_blog where BlogID = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            return item;
        }
    }
}
