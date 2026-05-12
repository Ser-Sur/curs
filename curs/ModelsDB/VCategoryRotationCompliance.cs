using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class VCategoryRotationCompliance
{
    public string Категория { get; set; } = null!;

    public int? ВсегоПодач { get; set; }

    public int? МинИнтервалДней { get; set; }

    public int? МаксИнтервалДней { get; set; }

    public decimal? СреднийИнтервалДней { get; set; }
}
