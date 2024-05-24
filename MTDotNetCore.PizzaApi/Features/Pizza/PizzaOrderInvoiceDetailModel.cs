namespace MTDotNetCore.PizzaApi.Features.Pizza
{
    public class PizzaOrderInvoiceDetailModel
    {
        public int PizzaOrderDetailsId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
        public string PizzaExtraName { get; set; }
        public decimal Price { get; set; }
    }
}
