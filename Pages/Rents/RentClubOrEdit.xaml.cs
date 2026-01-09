using pr28.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RentClubOrEdit.xaml
    /// </summary>
    public partial class RentClubOrEdit : Page
    {
        RentCs rent;
        ClubCs club;
        public RentClubOrEdit(RentCs _rent, ClubCs _club)
        {
            InitializeComponent();
            rent = _rent;
            club = _club;
            var clubs = MainWindow.mainWindow.clubs;
            if(rent != null)
            {
                string[] inputDate = rent.time_rent.ToString().Split(' ');
                string[] inputTime = inputDate[1].Split(':');
                nameClient.Text = rent.name_client;
                dateRent.Text = inputDate[0];
                timeRent.Text = $"{inputTime[0]}:{inputTime[1]}";
                mainLabel.Text = $"Изменить аренду клуба {rent.nameClub}";
                AddEditBtn.Content = "Изменить запись";
            } else
            {
                mainLabel.Text += club.name;
            }
        }

        private void acceptChanges(object sender, RoutedEventArgs e)
        {
            string[] timeElements = timeRent.Text.Split(':');
            if (string.IsNullOrEmpty(nameClient.Text) || !Regex.IsMatch(nameClient.Text, @"^[А-ЯЁ][а-яё]+(?: [А-ЯЁ][а-яё]+){1,2}$"))
            {
                MessageBox.Show("Введите корректное имя клиента");
                return;
            }

            if (!dateRent.SelectedDate.HasValue)
            {
                MessageBox.Show("Введите дату");
                return;
            }

            if (int.Parse(timeElements[0]) > 23 || int.Parse(timeElements[1]) > 59 || int.Parse(timeElements[0]) < 0 || int.Parse(timeElements[1]) < 00 || !Regex.IsMatch(timeRent.Text, @"^([01]?[0-9]|2[0-3]):([0-5][0-9])$"))
            {
                MessageBox.Show("Введите корректное время");
                return;
            }
            DateTime DateRent = dateRent.SelectedDate.Value.Date;
            TimeSpan.TryParse(timeRent.Text, out TimeSpan time);
            DateRent = DateRent.Add(time);
            if (rent == null)
            {
                rent = new RentCs(
                    time_rent: DateRent,
                    name_client: nameClient.Text,
                    idClub: club.id
                    );
                MainWindow.mainWindow.AddRents(rent);
                MessageBox.Show("Запрос выполнен");
                MainWindow.mainWindow.frame.Navigate(new Pages.Rents.Rent(club));
            } else
            {
                rent.name_client = nameClient.Text;
                rent.time_rent = DateRent;
                MainWindow.mainWindow.UpdateRents(rent);
                MessageBox.Show("Запрос выполнен");
                MainWindow.mainWindow.frame.Navigate(new Pages.Rents.Rent(club));
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Rents.Rent(club));
        }
    }
}
