using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class DishIngredient
{
    public int IngredientId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Unit { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<RecipeComm> RecipeComms { get; set; } = new List<RecipeComm>();
}
