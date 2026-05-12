using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class MealTypeDict
{
    public int MealTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public int? ServingOrder { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
