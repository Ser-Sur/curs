using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для wFindUnusedDishes.xaml
    /// </summary>
    public partial class wViewUnusedDishes : Window
    {
        public wViewUnusedDishes()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (KindergartenMenuContext _db = new())
            {
                _db.Menus.Load();
                _db.DishCategoriesDicts.Load();
                _db.Dishes.Load();
                listView.ItemsSource = _db.VFindUnusedDishes.ToList();
                listView.Focus();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
