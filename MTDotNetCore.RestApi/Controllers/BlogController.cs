using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTDotNetCore.RestApi.Controllers
{
    // https:/localhost:3000 => domain url
    // api/blog => endpoint


    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult Read()
        {
            return Ok("Read");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
