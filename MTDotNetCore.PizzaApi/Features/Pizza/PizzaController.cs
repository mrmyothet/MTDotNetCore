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
        public async Task<IActionResult> PizzaOrder(PizzaOrderRequest orderRequest)
        {
            string invoiceNo = DateTime.Now.ToString("yyyyMMddhhmmss");

            var pizza = _dbContext.Pizzas.FirstOrDefault(x => x.Id == orderRequest.PizzaId);
            if (pizza is null) return NotFound("No data found for PizzaId: " + orderRequest.PizzaId);

            decimal totalAmount = pizza.Price;

            List<PizzaExtraModel> lstExtras = new List<PizzaExtraModel>();
            List<PizzaOrderDetails> lstOrderDetails = new List<PizzaOrderDetails>();

            if (orderRequest.PizzaExtras is not null && orderRequest.PizzaExtras.Length > 0)
            {
                // SELECT * FROM Tbl_PizzaExtra WHERE PizzaExtraId IN (1,2,3,4)
                lstExtras = await _dbContext.PizzaExtras.Where(x => orderRequest.PizzaExtras.Contains(x.Id)).ToListAsync();

                totalAmount += lstExtras.Sum(x => x.Price);

                lstOrderDetails = orderRequest.PizzaExtras.Select(extraId => new PizzaOrderDetails()
                {
                    PizzaExtraId = extraId,
                    PizzaOrderInvoiceNo = invoiceNo,
                }).ToList();
            }

            //foreach (var extra in request.PizzaExtras)
            //{
            //    var extraItem = _dbContext.PizzaExtras.Where(x => x.Id == extra).FirstOrDefault();
            //    if (extraItem is not null)
            //    {
            //        totalAmount += extraItem.Price;

            //        lstOrderDetails.Add(new PizzaOrderDetails()
            //        {
            //            PizzaExtraId = extra,
            //            PizzaOrderInvoiceNo = invoiceNo,

            //        });

            //        extras.Add(extraItem);
            //    }
            //}

            PizzaOrder order = new PizzaOrder()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = totalAmount,
            };

            await _dbContext.PizzaOrders.AddAsync(order);
            await _dbContext.PizzaOrdersDetails.AddRangeAsync(lstOrderDetails);
            await _dbContext.SaveChangesAsync();

            PizzaOrderResponse response = new PizzaOrderResponse()
            {
                InvoiceNo = invoiceNo,
                Total = totalAmount,
                Message = "Thank you for your order! Enjoy your pizza.",
                Pizza = pizza,
                Extras = lstExtras,
            };

            return Ok(response);
        }
    }
}
