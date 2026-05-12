using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class VwDishServingDate
{
    public int DishId { get; set; }

    public string DishName { get; set; } = null!;

    public DateOnly MenuDate { get; set; }
}
