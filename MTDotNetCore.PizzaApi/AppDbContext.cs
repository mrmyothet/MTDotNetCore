using Microsoft.EntityFrameworkCore;
using MTDotNetCore.PizzaApi.Features.Pizza;

namespace MTDotNetCore.PizzaApi;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<PizzaModel> Pizzas { get; set; }

    public DbSet<PizzaExtraModel> PizzaExtras { get; set; }

    public DbSet<PizzaOrder> PizzaOrders { get; set; }

    public DbSet<PizzaOrderDetails> PizzaOrdersDetails { get; set; }
}
