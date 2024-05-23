namespace MTDotNetCore.PizzaApi.Features.Pizza
{
    public class PizzaOrderResponse
    {
        public string InvoiceNo { get; set; }

        public PizzaModel Pizza { get; set; }

        public List<PizzaExtraModel> Extras { get; set; }

        public decimal Total { get; set; }
    }
}
