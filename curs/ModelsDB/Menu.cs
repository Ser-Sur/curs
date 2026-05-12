using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class Menu
{
    public int MenuId { get; set; }

    public DateOnly MenuDate { get; set; }

    public int MealTypeId { get; set; }

    public int DishId { get; set; }

    public virtual Dish Dish { get; set; } = null!;

    public virtual MealTypeDict MealType { get; set; } = null!;
}
