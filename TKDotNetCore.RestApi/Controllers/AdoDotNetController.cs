using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using TKDotNetCore.RestApi.Models;

namespace TKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult Read()
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
    }
}
