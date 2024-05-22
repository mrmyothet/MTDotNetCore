using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MTDotNetCore.PizzaApi.Features.Pizza
{

    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public PizzaController()
        {
            _dbContext = new AppDbContext();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _dbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extras")]
        public async Task<IActionResult> GetPizzaExtrasAsync()
        {
            var lst = await _dbContext.PizzaExtras.ToListAsync();
            return Ok(lst);
        }
    }
}
