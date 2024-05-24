using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTDotNetCore.PizzaApi.Features.Pizza;

[Table("Tbl_PizzaExtra")]
public class PizzaExtraModel
{
    [Key]
    [Column("PizzaExtraId")]
    public int Id { get; set; }

    [Column("PizzaExtraName")]
    public string Name { get; set; }

    public decimal Price { get; set; }

    [NotMapped]
    public string PriceStr
    {
        get { return "$ " + Price; }
    }
}
