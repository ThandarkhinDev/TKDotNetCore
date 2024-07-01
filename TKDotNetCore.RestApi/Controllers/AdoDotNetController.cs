using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using TKDotNetCore.RestApi.Models;

namespace TKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            SqlConnection connection = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            /*List<BlogModel> lst = new List<BlogModel>();
            foreach (DataRow dr in dt.Rows)
            {
                BlogModel blog = new BlogModel();
                blog.BlogId = Convert.ToInt32(dr["blogid"]);
                blog.BlogTitle = Convert.ToString(dr["blogtitle"]);
                blog.BlogAuthor = Convert.ToString(dr["blogauthor"]);
                blog.BlogContent = Convert.ToString(dr["blogcontent"]);
                lst.Add(blog);
            }*/

            /*List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
                {
                    BlogId = Convert.ToInt32(dr["blogid"]),
                    BlogTitle = Convert.ToString(dr["blogtitle"]),
                    BlogAuthor = Convert.ToString(dr["blogauthor"]),
                    BlogContent = Convert.ToString(dr["blogcontent"])
                }
            ).ToList();*/

            List<BlogModel> lst = [.. dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["blogid"]),
                BlogTitle = Convert.ToString(dr["blogtitle"]),
                BlogAuthor = Convert.ToString(dr["blogauthor"]),
                BlogContent = Convert.ToString(dr["blogcontent"])
            }
            )];
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "SELECT * FROM [dbo].[Tbl_Blog] WHERE BlogId= @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0) return NotFound("No Data found");
            DataRow dr = dt.Rows[0];
            BlogModel item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["blogid"]),
                BlogTitle = Convert.ToString(dr["blogtitle"]),
                BlogAuthor = Convert.ToString(dr["blogauthor"]),
                BlogContent = Convert.ToString(dr["blogcontent"])
            };
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                 ([BlogTitle], [BlogAuthor], [BlogContent])
                                 VALUES
                                 (@BlogTitle, @BlogAuthor, @BlogContent)";
            SqlConnection connection = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Successfully Saved." : "Fail to save Data";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                                 SET [BlogTitle] = @BlogTitle,
                                     [BlogAuthor] = @BlogAuthor,
                                     [BlogContent] = @BlogContent
                                 WHERE [BlogId] = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Successfully Updated." : "Fail to update Data";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle)) conditions += "[BlogTitle] = @BlogTitle,";
            if (!string.IsNullOrEmpty(blog.BlogAuthor)) conditions += "[BlogAuthor] = @BlogAuthor,";
            if (!string.IsNullOrEmpty(blog.BlogContent)) conditions += "[BlogContent] = @BlogContent,";
            if (conditions.Length == 0) return NotFound("No Data To Be update");
            conditions = conditions.TrimEnd(',');
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                                 SET {conditions}
                                 WHERE [BlogId] = @BlogId";

            SqlConnection connection = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if (!string.IsNullOrEmpty(blog.BlogTitle)) cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            if (!string.IsNullOrEmpty(blog.BlogAuthor)) cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            if (!string.IsNullOrEmpty(blog.BlogContent)) cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Successfully Updated." : "Fail to update Data";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId= @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings._sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Successfully Deleted." : "Fail to delete Data";
            return Ok(message);
        }
    }
}
