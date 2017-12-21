using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ConnectionString = "datasource = 127.0.0.1; port = 3306; username = root; password =; database = atish ";
                MySqlConnection conn = new MySqlConnection(ConnectionString);




                string query = string.Format("SELECT * FROM atish.user_info WHERE name ='{0}' and password = '{1}';", textBox.Text, passwordBox.Password.ToString());
                MySqlCommand cmd = new MySqlCommand(query, conn);


                conn.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    textBox.Clear();
                    passwordBox.Clear();

                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch(Exception E)
            {
                MessageBox.Show("Login failed Error");
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
            this.Close();

        }
    }
}
