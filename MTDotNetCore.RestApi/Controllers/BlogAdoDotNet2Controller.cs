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
            string query = "select * from tbl_blog where BlogId = @BlogId";

            var lst = _adoDotNetService.Query<BlogModel>(query,
                new AdoDotNetParameter("BlogId", id));

            var item = lst.FirstOrDefault();

            if (item is null)
                return NotFound("Data not found for the Id: " + id);

            return Ok(lst);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                );

            string message = result > 0 ? "Saving successful." : "Saving failed.";

            if (message == "Saving failed.")
                return StatusCode(500, message);

            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            BlogModel item = FindById(id);

            if (item is null)
            {
                return NotFound("Data not found with the Id: " + id);
            }

            string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE [BlogId] = @BlogId";

            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent),
                new AdoDotNetParameter("@BlogId", id)
                );

            string message = result > 0 ? "Update successful." : "Update failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            BlogModel item = FindById(id);

            if (item is null)
            {
                return NotFound("Data not found with the Id: " + id);
            }

            // Arrange query 
            string conditions = string.Empty;

            if (!string.IsNullOrEmpty(blog.BlogTitle))
                conditions += "[BlogTitle] = @BlogTitle, ";

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
                conditions += "[BlogAuthor] = @BlogAuthor, ";

            if (!string.IsNullOrEmpty(blog.BlogContent))
                conditions += "[BlogContent] = @BlogContent, ";

            if (conditions.Length == 0)
                return NotFound("No data to update");

            conditions = conditions.Substring(0, conditions.Length - 2);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                            SET {conditions}
                            WHERE [BlogId] = @BlogId";

            // Arrange Parameters 
            List<AdoDotNetParameter> lstParameters = new List<AdoDotNetParameter>();
            lstParameters.Add(new AdoDotNetParameter("@BlogId", id));

            if (blog.BlogTitle is not null)
                lstParameters.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));

            if (blog.BlogAuthor is not null)
                lstParameters.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));

            if (blog.BlogContent is not null)
                lstParameters.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));

            // Act
            int result = _adoDotNetService.Execute(query, lstParameters.ToArray());

            string message = result > 0 ? "Patch Successful." : "Patch Failed.";
            return Ok(message);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("No data found for the Id: " + id);
            }

            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", id));

            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            return Ok(message);
        }
        private BlogModel FindById(int Id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";

            var lst = _adoDotNetService.Query<BlogModel>(query,
                new AdoDotNetParameter("BlogId", Id));

            var item = lst.FirstOrDefault();
            return item;
        }
    }
}
