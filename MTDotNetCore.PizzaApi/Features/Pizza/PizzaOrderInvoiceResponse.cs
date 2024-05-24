namespace MTDotNetCore.PizzaApi.Features.Pizza
{
    public class PizzaOrderInvoiceResponse
    {
        public PizzaOrderInvoiceHeadModel Order { get; set; }
        public List<PizzaOrderInvoiceDetailModel> OrderDetail { get; set; }
    }
}
