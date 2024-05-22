using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTDotNetCore.PizzaApi;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<PizzaModel> Pizzas { get; set; }

    public DbSet<PizzaExtraModel> PizzaExtras { get; set; }
}

[Table("Tbl_Pizza")]
public class PizzaModel
{
    [Key]
    [Column("PizzaId")]
    public int Id { get; set; }

    [Column("Pizza")]
    public string Name { get; set; }

    public decimal Price { get; set; }

    [NotMapped]
    public string PriceStr => "$ " + Price;
}

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
