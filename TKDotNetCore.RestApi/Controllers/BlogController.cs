using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult Read()
        {
            return Ok("Read ok");
        }
        [HttpGet("{id}")]
        public IActionResult GetDataById(int id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Create ok");
        }
        [HttpPut]
        public IActionResult Update()
        {
            return Ok("Update ok");
        }
        [HttpPatch]
        public IActionResult Patch()
        {
            return Ok("Patch Ok");
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Delete ok");
        }
    }
}
