using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class RecipeComm
{
    public int RecipeId { get; set; }

    public int DishId { get; set; }

    public int IngredientId { get; set; }

    public decimal Quantity { get; set; }

    public virtual Dish Dish { get; set; } = null!;

    public virtual DishIngredient Ingredient { get; set; } = null!;
}
