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
        public List<RentCs> rents = new List<RentCs>();
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

        public void AddClubs(ClubCs club)
        {
            using (var connect = new MySqlConnection(connection))
            {
                connect.Open();
                string query = "INSERT INTO club (name, adress) VALUES (@name, @adress);";
                using(var command = new MySqlCommand(query, connect))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@name", club.name);
                        command.Parameters.AddWithValue("@adress", club.adress);
                        command.ExecuteNonQuery();
                    } catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        return;
                    }
                }
            }
        }

        public void UpdateClubs(ClubCs club)
        {
            using(var connect = new MySqlConnection(connection))
            {
                connect.Open();
                string query = "UPDATE club set name = @name, adress = @adress WHERE id = @id";
                using(var command = new MySqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@name", club.name);
                    command.Parameters.AddWithValue("@adress", club.adress);
                    command.Parameters.AddWithValue("@id", club.id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteClubs(ClubCs club)
        {
            using(var connect = new MySqlConnection(connection))
            {
                connect.Open();
                string query = "DELETE FROM club where id = @id";
                using(var command = new MySqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@id", club.id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void LoadRents(int clubId)
        {
            rents.Clear();
            MySqlConnection mySqlConnection = new MySqlConnection(connection);
            mySqlConnection.Open();
            string query = $"SELECT * FROM rents JOIN club ON rents.idClub = club.id WHERE idClub = {clubId}";
            MySqlDataReader reader = Connection.Query(query, mySqlConnection);
            while (reader.Read())
            {
                rents.Add(new RentCs(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetString(5)
                    ));
            }
            mySqlConnection.Close();
        }
    }
}
