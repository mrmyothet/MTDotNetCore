using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTDotNetCore.PizzaApi.Features.Pizza;

[Table("Tbl_PizzaOrderDetails")]
public class PizzaOrderDetails
{
    [Key]
    public int PizzaOrderDetailsId { get; set; }
    public string PizzaOrderInvoiceNo { get; set; }
    public int PizzaExtraId { get; set; }
}
