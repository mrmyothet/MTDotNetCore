namespace MTDotNetCore.PizzaApi.Features.Pizza
{
    public class PizzaOrderResponse
    {
        public string InvoiceNo { get; set; }

        public decimal Total { get; set; }

        public string Message { get; set; }

        public PizzaModel Pizza { get; set; }

        public List<PizzaExtraModel> Extras { get; set; }

    }
}
