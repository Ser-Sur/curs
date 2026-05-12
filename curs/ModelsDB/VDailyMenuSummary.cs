using System;
using System.Collections.Generic;

namespace curs.ModelsDB;

public partial class VDailyMenuSummary
{
    public DateOnly Дата { get; set; }

    public string? Завтрак { get; set; }

    public string? Обед { get; set; }

    public string? Полдник { get; set; }
}
