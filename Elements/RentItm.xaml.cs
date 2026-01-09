using pr28.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr28.Elements
{
    /// <summary>
    /// Логика взаимодействия для RentItm.xaml
    /// </summary>
    public partial class RentItm : UserControl
    {
        RentCs rent;
        ClubCs club;
        public RentItm(RentCs _rent, ClubCs _club)
        {
            InitializeComponent();
            rent = _rent;
            club = _club;
            nameClub.Text = rent.nameClub;
            dateRent.Text = rent.time_rent.ToString("dd MMMM HH:mm");
            nameClient.Text = rent.name_client;
        }

        private void editRent(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Rents.RentClubOrEdit(rent, club));
        }

        private void deleteRent(object sender, RoutedEventArgs e)
        {
            try
            {
                var deleteDialogResult = MessageBox.Show($"Вы точно хотите удалить аренду {rent.name_client}?", "Удаление", MessageBoxButton.YesNo);
                if (deleteDialogResult == MessageBoxResult.Yes)
                {
                    MainWindow.mainWindow.DeleteRents(rent);
                    MessageBox.Show("Запрос выполнен");
                    MainWindow.mainWindow.frame.Navigate(new Pages.Rents.Rent(club));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
