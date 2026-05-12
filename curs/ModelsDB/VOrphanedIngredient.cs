using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class VOrphanedIngredient
{
    public int IngredientId { get; set; }

    public string Продукт { get; set; } = null!;

    public int ЕдИзмерения { get; set; }

    public string? Примечание { get; set; }
}
