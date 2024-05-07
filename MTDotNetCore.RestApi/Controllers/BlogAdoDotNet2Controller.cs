using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTDotNetCore.RestApi.Models;
using System.Data;
using System.Data.SqlClient;
using MTDotNetCore.Shared;

namespace MTDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";

            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            return Ok();
        }
        private BlogModel FindById(int Id)
        {
            BlogModel blog = new BlogModel();
            return blog;
        }
    }
}
