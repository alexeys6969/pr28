using MySql.Data.MySqlClient;
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

namespace pr28.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для ClubAddOrEdit.xaml
    /// </summary>
    public partial class ClubAddOrEdit : Page
    {
        ClubCs club;
        public ClubAddOrEdit(ClubCs _club)
        {
            InitializeComponent();
            club = _club;
            if(club != null)
            {
                mainLabel.Text = "Изменить клуб";
                AddEditBtn.Content = "Изменить клуб";
                nameClub.Text = club.name;
                adressClub.Text = club.adress;
            }
        }

        private void acceptChanges(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameClub.Text))
            {
                MessageBox.Show("Введите название клуба");
                return;
            }

            if (string.IsNullOrEmpty(adressClub.Text) || !Regex.IsMatch(adressClub.Text, @"^(?:ул\.|просп\.|пер\.|б-р|наб\.)\s[А-Яа-яЁё\s\-]+,\s*\d+[А-Яа-я]?(?:\s?[А-Яа-я]\.\s?\d+)?(?:\s?кв\.\s?\d+)?$"))
            {
                MessageBox.Show("Введите корректный адрес клуба");
                return;
            }
            if (club == null)
            {
                try
                {
                    club = new ClubCs(
                        name: nameClub.Text,
                        adress: adressClub.Text
                        );
                    MainWindow.mainWindow.AddClubs(club);
                    MessageBox.Show("Запрос выполнен");
                    MainWindow.mainWindow.frame.Navigate(new Pages.Clubs.Club());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return;
                }

            } else
            {
                try
                {
                    club.name = nameClub.Text;
                    club.adress = adressClub.Text;
                    MainWindow.mainWindow.UpdateClubs(club);
                    MessageBox.Show("Запрос выполнен");
                    MainWindow.mainWindow.frame.Navigate(new Pages.Clubs.Club());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return;
                }

            }

        }

        private void exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Clubs.Club());
        }
    }
}
