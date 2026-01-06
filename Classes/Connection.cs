using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr28.Classes
{
    public class Connection
    {
        public static MySqlDataReader Query(string query, MySqlConnection connection)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = new MySqlCommand(query, connection);
                return command.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
