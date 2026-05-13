using curs.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace curs
{
    /// <summary>
    /// Логика взаимодействия для wViewDishServingDate.xaml
    /// </summary>
    public partial class wViewDishServingDate : Window
    {
        public wViewDishServingDate()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (KindergartenMenuContext _db = new())
            {
                listView.ItemsSource = _db.VwDishServingDates.ToList();
                listView.Focus();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFind.Text))
            {
                using (KindergartenMenuContext _db = new())
                {
                    listView.ItemsSource = _db.VwDishServingDates.ToList();
                    listView.Focus();
                }
            }
            else
            {
                List<VwDishServingDate> listItem = (List<VwDishServingDate>)listView.ItemsSource;
                var filtered = listItem.Where(p => p.DishName.Contains(tbFind.Text));
                listView.ItemsSource = filtered.ToList();
            }
        }
    }
}
