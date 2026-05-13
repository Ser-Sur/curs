using curs.ModelsDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curs.ModelsDB_DTO
{
    public partial class FnCheckMenuCompleteness
    {
        [Column("meal_type_ID")]
        public int MealTypeId { get; set; }

        [Column("Отсутствующий_прием_пищи")]
        public string TypeName { get; set; } = null!;

        [Column("Порядок_подачи")]
        public int? ServingOrder { get; set; }

        public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
    }
}
