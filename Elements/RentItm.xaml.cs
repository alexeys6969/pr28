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
        public RentItm(RentCs _rent)
        {
            InitializeComponent();
            rent = _rent;
            nameClub.Text = rent.nameClub;
            dateRent.Text = rent.time_rent.ToString("dd MMMM HH:mm");
            nameClient.Text = rent.name_client;
        }

        private void editRent(object sender, RoutedEventArgs e)
        {

        }

        private void deleteRent(object sender, RoutedEventArgs e)
        {

        }
    }
}
