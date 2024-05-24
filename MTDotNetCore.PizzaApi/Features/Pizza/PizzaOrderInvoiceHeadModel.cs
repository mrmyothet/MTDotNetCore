namespace MTDotNetCore.PizzaApi.Features.Pizza
{
    public class PizzaOrderInvoiceHeadModel
    {
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Pizza { get; set; }
        public decimal Price { get; set; }
    }
}
