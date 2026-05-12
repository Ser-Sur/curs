using curs.ModelsDB;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для wAddEdit.xaml
    /// </summary>
    public partial class wAddEdit : Window
    {
        KindergartenMenuContext _db = new();
        ModelsDB.Dish _dish = new ();


        public wAddEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDB();
        }

        void LoadDB()
        {
            _dish = new();
            this.DataContext = _dish;
            _db.Dishes.Load();
            cbBreakfastFirst.ItemsSource = _db.Dishes.ToList();
            cbBreakfastFirst.DisplayMemberPath = "DishName";
            cbBreakfastDrink.ItemsSource = _db.Dishes.ToList();
            cbBreakfastDrink.DisplayMemberPath = "DishName";
            cbMealFirst.ItemsSource = _db.Dishes.ToList();
            cbMealFirst.DisplayMemberPath = "DishName";
            cbMealSecond.ItemsSource = _db.Dishes.ToList();
            cbMealSecond.DisplayMemberPath = "DishName";
            cbMealDrink.ItemsSource = _db.Dishes.ToList();
            cbMealDrink.DisplayMemberPath = "DishName";
            cbLunchDessert.ItemsSource = _db.Dishes.ToList();
            cbLunchDessert.DisplayMemberPath = "DishName";
            cbLunchDrink.ItemsSource = _db.Dishes.ToList();
            cbLunchDrink.DisplayMemberPath = "DishName";
        }

        private void AddEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (KindergartenMenuContext _bd = new())
                { 
                    DateOnly _date = DateOnly.FromDateTime((DateTime)dpDate.SelectedDate);
                    List<ModelsDB.Menu> AddAtMenu = new();

                    var bebe = (Dish)cbBreakfastFirst.SelectedItem;

                    if (cbBreakfastFirst.SelectedItem is Dish && cbBreakfastFirst.SelectedItem != null)
                    {
                        AddAtMenu.Add(new ModelsDB.Menu()
                        {
                            DishId = ((Dish)cbBreakfastFirst.SelectedItem).DishId,
                            MealTypeId = 1,
                            MenuDate = _date
                        });
                    }

                    if (cbBreakfastDrink.SelectedItem is Dish && cbBreakfastDrink.SelectedItem != null)
                    {
                        AddAtMenu.Add(new()
                        {
                            DishId = ((Dish)cbBreakfastDrink.SelectedItem).DishId,
                            MealTypeId = 1,
                            MenuDate = _date
                        });
                    }

                    if (cbMealFirst.SelectedItem is Dish && cbMealFirst.SelectedItem != null)
                    {
                        AddAtMenu.Add(new()
                        {
                            DishId = ((Dish)cbMealFirst.SelectedItem).DishId,
                            MealTypeId = 2,
                            MenuDate = _date
                        });
                    }

                    if (cbMealSecond.SelectedItem is Dish && cbMealSecond.SelectedItem != null)
                    {
                        AddAtMenu.Add(new()
                        {
                            DishId = ((Dish)cbMealSecond.SelectedItem).DishId,
                            MealTypeId = 2,
                            MenuDate = _date
                        });
                    }

                    if (cbMealDrink.SelectedItem is Dish && cbMealDrink.SelectedItem != null)
                    {
                        AddAtMenu.Add(new()
                        {
                            DishId = ((Dish)cbMealDrink.SelectedItem).DishId,
                            MealTypeId = 2,
                            MenuDate = _date
                        });
                    }

                    if (cbLunchDessert.SelectedItem is Dish && cbLunchDessert.SelectedItem != null)
                    {
                        AddAtMenu.Add(new()
                        {
                            DishId = ((Dish)cbLunchDessert.SelectedItem).DishId,
                            MealTypeId = 3,
                            MenuDate = _date
                        });
                    }

                    if (cbLunchDrink.SelectedItem is Dish &&  cbLunchDrink.SelectedItem != null)
                    {
                        AddAtMenu.Add(new ModelsDB.Menu
                        {
                            DishId = ((Dish)cbLunchDrink.SelectedItem).DishId,
                            MealTypeId = 3,
                            MenuDate = _date
                        });
                    }


                    _bd.Menus.AddRange(AddAtMenu);
                    _bd.SaveChanges();
                    this.Close();
                }
            }
            catch (DbUpdateException dbEx) { MessageBox.Show($"Ошибка сохранения в базу данных: {dbEx.InnerException?.Message ?? dbEx.Message}"); }
            catch (Exception ex) { MessageBox.Show($"Произошла ошибка: {ex.Message}"); }

            //_db.ChangeTracker.Clear();

        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
