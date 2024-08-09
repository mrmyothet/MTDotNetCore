using System;
using System.Collections.Generic;

namespace MTDotNetCore.ConsoleAppEFCore.Database.Models;

public partial class TblPizzaOrderDetail
{
    public int PizzaOrderDetailsId { get; set; }

    public string PizzaOrderInvoiceNo { get; set; } = null!;

    public int PizzaExtraId { get; set; }
}
