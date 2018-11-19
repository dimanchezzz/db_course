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
    /// Логика взаимодействия для My_contract.xaml
    /// </summary>
    public partial class My_contract : Page
    {
        public My_contract()
        {
            InitializeComponent();
            RefreshList();
        }
        int Id_service;
        string statuss;

        private void RefreshList()
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string take = "exec take_name_serv_bef_id @id="+main_user_window.Id_user+"";
                SqlCommand commandd = new SqlCommand(take, connection);
                SqlDataReader reader = commandd.ExecuteReader();

                List<string> list = new List<string>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetValue(0).ToString());
                    }
                }
                reader.Close();
                services.ItemsSource = list;
            }
        }

        private void services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string select = services.SelectedItem.ToString();
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string take = " exec Take_service_info @name='" + select + "';";
                SqlCommand commandd = new SqlCommand(take, connection);
                SqlDataReader reader = commandd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Id_service = int.Parse(reader.GetValue(0).ToString());
                    }
                }
                reader.Close();
                string take_info_contr = "exec take_contr_info @id_service=" + Id_service + ",@id_client=" + main_user_window.Id_user + ";";
                SqlCommand com = new SqlCommand(take_info_contr, connection);
                SqlDataReader read = com.ExecuteReader();
                if(read.HasRows)
                {
                    while(read.Read())
                    {
                        date_start.Text = "Start date: " + read.GetValue(4);
                        date_end.Text = "End date: " + read.GetValue(5);
                        pay.Text = "Pay: " + read.GetValue(8);
                        debt.Text = "Debt: " + read.GetValue(9);
                        status.Text = "Status: " + read.GetValue(6);
                        statuss = read.GetValue(6).ToString();
                    }
                    read.Close();
                }
            }
            if (statuss == "new")
                to_pay.IsEnabled = false;
        }

        private void payment_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void payment_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void to_pay_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
