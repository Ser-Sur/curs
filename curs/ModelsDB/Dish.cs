using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class Dish
{
    public int DishId { get; set; }

    public string DishName { get; set; } = null!;

    public int CategoryId { get; set; }

    public string? Recipe { get; set; }

    public virtual DishCategoriesDict Category { get; set; } = null!;

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<RecipeComm> RecipeComms { get; set; } = new List<RecipeComm>();
}
