using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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

        [HttpPost]
        public async Task<IActionResult> PizzaOrder(PizzaOrderRequest request)
        {
            string invoiceNo = DateTime.Now.ToString("yyyyMMddhhmmss");

            var pizza = _dbContext.Pizzas.FirstOrDefault(x => x.Id == request.PizzaId);
            decimal totalAmount = pizza.Price;


            List<PizzaOrderDetails> lst = new List<PizzaOrderDetails>();
            List<PizzaExtraModel> extras = new List<PizzaExtraModel>();

            foreach (var extra in request.PizzaExtras)
            {
                var extraItem = _dbContext.PizzaExtras.Where(x => x.Id == extra).FirstOrDefault();
                if (extraItem is not null)
                {
                    totalAmount += extraItem.Price;

                    lst.Add(new PizzaOrderDetails()
                    {
                        PizzaExtraId = extra,
                        PizzaOrderInvoiceNo = invoiceNo,

                    });

                    extras.Add(extraItem);
                }
            }

            PizzaOrder order = new PizzaOrder()
            {
                PizzaId = request.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = totalAmount,
            };

            await _dbContext.PizzaOrders.AddAsync(order);
            await _dbContext.PizzaOrdersDetails.AddRangeAsync(lst);
            await _dbContext.SaveChangesAsync();

            PizzaOrderResponse response = new PizzaOrderResponse()
            {
                InvoiceNo = invoiceNo,
                Pizza = pizza,
                Extras = extras,
                Total = totalAmount
            };

            return Ok(response);
        }
    }
}
