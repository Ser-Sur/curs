using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class VCategoryPopularity
{
    public string Категория { get; set; } = null!;

    public int? КоличествоПодач { get; set; }
}
