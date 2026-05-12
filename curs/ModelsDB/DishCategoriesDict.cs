using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class DishCategoriesDict
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
