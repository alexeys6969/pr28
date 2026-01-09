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
    /// Логика взаимодействия для ClubItm.xaml
    /// </summary>
    public partial class ClubItm : UserControl
    {
        ClubCs club;
        public ClubItm(ClubCs _club)
        {
            InitializeComponent();
            club = _club;
            nameClub.Text = club.name;
            adresClub.Text = club.adress;
        }

        private void editClub(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Clubs.ClubAddOrEdit(club));
        }

        private void deleteClub(object sender, RoutedEventArgs e)
        {
            try
            {
                var deleteDialogResult = MessageBox.Show($"Вы точно хотите удалить клуб {club.name}?", "Удаление", MessageBoxButton.YesNo);
                if(deleteDialogResult == MessageBoxResult.Yes)
                {
                    MainWindow.mainWindow.DeleteClubs(club);
                    MessageBox.Show("Запрос выполнен");
                    MainWindow.mainWindow.frame.Navigate(new Pages.Clubs.Club());
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void checkRent(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Rents.Rent(club));
        }
    }
}
