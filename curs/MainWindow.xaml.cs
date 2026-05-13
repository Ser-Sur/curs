using curs.ModelsDB;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace curs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int countClickOnSortByMealType = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabItem1_Loaded(object sender, RoutedEventArgs e)
        {
            LoadViewInListViewM();
        }

        private void TabItem2_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInListViewD_RC();
        }

        void LoadViewInListViewM()
        {
            using (KindergartenMenuContext _db = new())
            {
                int selectedIndex = listViewM.SelectedIndex;
                _db.Menus.Load();
                _db.MealTypeDicts.Load();
                _db.Dishes.Load();
                listViewM.ItemsSource = _db.VDailyMenuSummaries.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex >= listViewM.Items.Count) selectedIndex = listViewM.Items.Count - 1;
                    listViewM.SelectedIndex = selectedIndex;
                    listViewM.ScrollIntoView(listViewM.SelectedItem);
                }
                listViewM.Focus();
            }
        }

        void LoadDBInListViewD_RC()
        {
            using (KindergartenMenuContext _db = new())
            {
                int selectedIndexD = listViewD.SelectedIndex;
                int selectedIndexRC = listViewRC.SelectedIndex;
                _db.Menus.Load();
                _db.DishCategoriesDicts.Load();
                _db.DishIngredients.Load();
                listViewD.ItemsSource = _db.Dishes.ToList();
                if (selectedIndexD != -1)
                {
                    if (selectedIndexD >= listViewD.Items.Count) selectedIndexD = listViewD.Items.Count - 1;
                    listViewD.SelectedIndex = selectedIndexD;
                    listViewD.ScrollIntoView(listViewD.SelectedItem);
                }
                listViewRC.ItemsSource = _db.RecipeComms.ToList();
                if (selectedIndexRC != -1)
                {
                    if (selectedIndexRC >= listViewRC.Items.Count) selectedIndexRC = listViewRC.Items.Count - 1;
                    listViewRC.SelectedIndex = selectedIndexRC;
                    listViewRC.ScrollIntoView(listViewRC.SelectedItem);
                }
                listViewD.Focus();
            }
        }

        private void FindUnusedDishes_Click(object sender, RoutedEventArgs e)
        {
            // №4
            wViewUnusedDishes fud = new();
            fud.Owner = this;
            fud.ShowDialog();
        }

        private void CheckMenuCompleteness_Click(object sender, RoutedEventArgs e)
        {
            // №7
            OpenSelectTimeGapWindow();
            if (LinkTimeforTFunc.isForth)
            {
                wFnCheckMenuCompleteness fcmc = new();
                fcmc.Owner = this;
                fcmc.ShowDialog();
            }
            LinkTimeforTFunc.dateStart = null;
            LinkTimeforTFunc.dateEnd = null;
            LinkTimeforTFunc.isForth = false;
        }

        private void GetvDMSByDateRange_Click(object sender, RoutedEventArgs e)
        {
            // №11

        }

        private void SortvDMSByMealType_Click(object sender, RoutedEventArgs e)
        {
            // №12
            if (countClickOnSortByMealType == 0)
            {
                //По возрастанию
                countClickOnSortByMealType = 1;
            }
            else if (countClickOnSortByMealType == 1)
            {
                //По убыванию
                countClickOnSortByMealType = 2;
            }
            else
            {
                //По умолчанию
                countClickOnSortByMealType = 0;
            }
        }

        private void SaveWeeklyShoppingList_Click(object sender, RoutedEventArgs e)
        {
            // №13

        }

        bool OpenSelectTimeGapWindow()
        {
            wSelectTimeGap t = new();
            t.Owner = this;
            t.ShowDialog();
            if (LinkTimeforTFunc.isForth) return true;
            else return false;
        }

        private void EditAddM_Click(object sender, RoutedEventArgs e)
        {
            if (listViewM.SelectedItem != null && listViewM.SelectedItems.Count == 1)
            {
                LinkAddEditMenu.vdms = (VDailyMenuSummary)listViewM.SelectedItem;
                wAddEdit f = new();
                f.Owner = this;
                f.ShowDialog();
            }
            else if (listViewM.SelectedItem == null)
            {
                LinkAddEditMenu.vdms = null;
                wAddEdit f = new();
                f.Owner = this;
                f.ShowDialog();
            }
            else MessageBox.Show("");
            LoadViewInListViewM();
        }

        private void DeleteM_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    ModelsDB.Menu row = (ModelsDB.Menu)listViewM.SelectedValue;
                    if (row != null)
                    {
                        using (KindergartenMenuContext _db = new())
                        {
                            _db.Menus.Remove(row);
                            _db.SaveChanges();
                            LoadViewInListViewM();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else listViewM.Focus();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

        }

        private void CategoryPopularity_Click(object sender, RoutedEventArgs e)
        {
            // №1
            wViewCategoryPopularity cp = new();
            cp.Owner = this;
            cp.ShowDialog();
        }

        private void CategoryRotationCompliance_Click(object sender, RoutedEventArgs e)
        {
            // №2
            wViewCategoryRotationCompliance crc = new();
            crc.Owner = this;
            crc.ShowDialog();
        }

        private void DishServingDates_Click(object sender, RoutedEventArgs e)
        {
            // №6
            wViewDishServingDate dsd = new();
            dsd.Owner = this;
            dsd.ShowDialog();
        }

        private void GetConsecutiveServingDays_Click(object sender, RoutedEventArgs e)
        {
            // №10

        }

        private void CountDishServings_Click(object sender, RoutedEventArgs e)
        {
            // №14

        }
    }
}