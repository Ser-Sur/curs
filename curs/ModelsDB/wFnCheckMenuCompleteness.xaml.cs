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

namespace curs.ModelsDB
{
    /// <summary>
    /// Логика взаимодействия для wFnCheckMenuCompleteness.xaml
    /// </summary>
    public partial class wFnCheckMenuCompleteness : Window
    {
        public wFnCheckMenuCompleteness()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = $"Отсутствующие {LinkTimeforTFunc.dateStart} приемы пищи";
            using (KindergartenMenuContext _db = new())
            {
                listView.ItemsSource = _db.GetCheckMenuCompleteness((DateOnly)LinkTimeforTFunc.dateStart).ToList();
                listView.Focus();
            }
        }
    }
}
