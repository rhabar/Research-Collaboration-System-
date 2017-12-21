using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace WpfApplication2
{
    public class ConnectionMySQL
    {
        static string ConnectionString = "datasource = 127.0.0.1; port = 3306; username = root; password =; database = atish ";
        MySqlConnection conn = new MySqlConnection(ConnectionString);
        public ConnectionMySQL()
        {


            try
            {
                // Open the database
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }


}
