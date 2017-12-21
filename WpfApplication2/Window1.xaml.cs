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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static string gender;
      

        public Window1()
        {
            InitializeComponent();
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            gender = (string)(sender as RadioButton).Content;
        }
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            gender = (string)(sender as RadioButton).Content;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            
            string password;
            try
            {
                
                string passp = passwordBox.Password.ToString();
                string passcp = passwordBox1.Password.ToString();
                if (passp.Equals(passcp))
                {
                    password = passp;

                    

                }
                else
                {
                    passwordBox.Clear();
                    passwordBox1.Clear();
                    MessageBox.Show("Password Doesn't Matched");
                }

            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }

            string ConnectionString = "datasource = 127.0.0.1; port = 3306; username = root; password =; database = atish ";
             MySqlConnection conn = new MySqlConnection(ConnectionString);

           


            string query =string.Format("INSERT INTO atish.user_info(`id`, `name`, `password`, `email`, `DOB`, `gender`) VALUES ( '' , '" + textBox.Text + "', '{0}', '" + textBox1.Text + "','" + date.Text + "','" + gender + "');",passwordBox.Password.ToString()) ;
            
            MySqlCommand MyCommand = new MySqlCommand(query, conn );
            MySqlDataReader MyReader;
            conn.Open();
            
            MyReader = MyCommand.ExecuteReader();

            passwordBox.Clear();
            passwordBox1.Clear();
            textBox.Clear();
            textBox1.Clear();
            MessageBox.Show("Congratulation!!You are Registered Now");
            








        }
    }
}
