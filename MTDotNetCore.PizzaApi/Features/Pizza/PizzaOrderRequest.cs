namespace MTDotNetCore.PizzaApi.Features.Pizza;

public class PizzaOrderRequest
{
    public int PizzaId { get; set; }

    public int[]? PizzaExtras { get; set; }
}