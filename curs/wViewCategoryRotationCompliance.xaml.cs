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
    /// Логика взаимодействия для wViewCategoryRotationCompliance.xaml
    /// </summary>
    public partial class wViewCategoryRotationCompliance : Window
    {
        public wViewCategoryRotationCompliance()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (KindergartenMenuContext _db = new())
            {
                listView.ItemsSource = _db.VCategoryRotationCompliances.ToList();
                listView.Focus();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
