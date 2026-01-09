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

namespace pr28.Pages.Rents
{
    /// <summary>
    /// Логика взаимодействия для Rent.xaml
    /// </summary>
    public partial class Rent : Page
    {
        ClubCs club;
        public Rent(ClubCs _club)
        {
            InitializeComponent();
            club = _club;
            rentOfClub.Text += club.name;
            MainWindow.mainWindow.LoadRents(club.id);
            var rents = MainWindow.mainWindow.rents;
            foreach (var rent in rents)
            {
                parent.Children.Add(new Elements.RentItm(rent));
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Clubs.Club());
        }
    }
}
