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
using System.Data.SqlClient;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Personal_Area.xaml
    /// </summary>
    public partial class Personal_Area : Page
    {
        public void  Take_info()
        {
            string take = "exec Take_user_info @id="+main_user_window.Id_user+";";
            using  (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(take, connection);
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        adress.Text = reader.GetValue(2).ToString();
                        city.Text = reader.GetValue(3).ToString();
                        phone_number.Text = reader.GetValue(4).ToString();
                        email.Text = reader.GetValue(5).ToString();
                        password.Text = reader.GetValue(6).ToString();
                        pasport.Text = reader.GetValue(9).ToString();
                    }
                }
                reader.Close();
            }
        }
        public  Personal_Area()
        {
            InitializeComponent();
            isEnable += Isena;
            Take_info();


        }

        private void agree_Click(object sender, RoutedEventArgs e)
        {
            info_panel.IsEnabled = true;

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            string Update_user = @"exec Update_client   @adress='" + adress.Text + "', @city='" + city.Text + "' , @number=" + phone_number.Text + " , @email='" + email.Text + "' , @password='" + password.Text + "' , @passport='" + pasport.Text + "' , @id=" + main_user_window.Id_user + "";
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Update_user, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show("Update User info", "Info");
            }





            info_panel.IsEnabled = false;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void phone_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
        public delegate void MethodCHeck();
        public static event MethodCHeck isEnable;
        public void Isena()
        {
            if (adress.Text == "" || city.Text == "" || phone_number.Text == "" || password.Text == "" || pasport.Text == "" || email.Text == "" || password.Text.Length<4)

            {
                save.IsEnabled = false;
            }
            else
            {
                save.IsEnabled = true;
            }
        }
        private void amount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            isEnable();
        }
    }
}

