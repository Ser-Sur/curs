using curs.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//scaffold-dbcontext "Server=localhost\sqlexpress; Database=KindergartenMenu; User=исп-31; Password=1234567890; Encrypt=false" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsDB -force

namespace curs
{
    public static class LinkAddEditMenu
    {
        public static VDailyMenuSummary? vdms;
    }

    public static class LinkTimeforTFunc
    {
        public static DateOnly? dateStart;
        public static DateOnly? dateEnd;
        public static bool isForth = false; // Дальше?
    }
}
