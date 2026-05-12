using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
    /// Логика взаимодействия для wSelectTimeGap.xaml
    /// </summary>
    public partial class wSelectTimeGap : Window
    {
        public wSelectTimeGap()
        {
            InitializeComponent();
        }

        private void Forth_Click(object sender, RoutedEventArgs e)
        {
            LinkTimeforTFunc.timeStart = dpDateStart.SelectedDate;
            LinkTimeforTFunc.timeEnd = dpDateEnd.SelectedDate;
            LinkTimeforTFunc.isForth = true;
            this.Close();
        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            LinkTimeforTFunc.timeStart = null;
            LinkTimeforTFunc.timeEnd = null;
            LinkTimeforTFunc.isForth = false;
            this.Close();
        }
    }
}
