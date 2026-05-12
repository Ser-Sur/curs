using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class VFindUnusedDish
{
    public int DishId { get; set; }

    public string НазваниеБлюда { get; set; } = null!;

    public string? Категория { get; set; }
}
