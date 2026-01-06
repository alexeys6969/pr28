using MySql.Data.MySqlClient;
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

namespace pr28
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public List<ClubCs> clubs = new List<ClubCs>();
        public static List<RentCs> rents = new List<RentCs>();
        public static string connection = "Server=localhost;Port=3307;Uid=root;Database=computerClub";
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            frame.Navigate(new Pages.Clubs.Club());
        }

        public void LoadClubs()
        {
            clubs.Clear();
            MySqlConnection mySqlConnection = new MySqlConnection(connection);
            mySqlConnection.Open();
            string query = "SELECT * FROM club";
            MySqlDataReader reader = Connection.Query(query, mySqlConnection);
            while (reader.Read())
            {
                clubs.Add(new ClubCs(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)
                    ));
            }
            mySqlConnection.Close();
        }
    }
}
