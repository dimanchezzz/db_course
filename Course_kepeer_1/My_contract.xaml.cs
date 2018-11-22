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
using System.Data;

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
            to_pay.IsEnabled = false;
        }
        int Id_service;
        string statuss;
        float Debtt;

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
                        Debtt = float.Parse(read.GetValue(9).ToString());
                        status.Text = "Status: " + read.GetValue(6);
                        statuss = read.GetValue(6).ToString();
                    }
                    read.Close();
                }
            }
            if (statuss == "active" && payment.Text != "")
                to_pay.IsEnabled = true;
            else
                to_pay.IsEnabled = false;
        }

        private void payment_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(payment.Text=="")
            {
                to_pay.IsEnabled = false;
            }
            else
            {
                to_pay.IsEnabled = true;
            }
        }
        public delegate void MethodCHeck();
        public static event MethodCHeck Purse;
        public static event MethodCHeck refresh;

        private void payment_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!payment.Text.Contains(".") && payment.Text.Length != 0)))
            {
                e.Handled = true;
            }

        }

        private void to_pay_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                if(float.Parse(payment.Text.ToString())>Debtt)
                {
                    MessageBox.Show("Pay>debt");
                    payment.Clear();
                    return;
                }
                else if (float.Parse(payment.Text.ToString()) == Debtt)
                {
                    using (SqlConnection connection = new SqlConnection(Hash.connect_str))
                    {

                        float pu = main_user_window.pursee - float.Parse(payment.Text);
                        connection.Open();
                        string take_purse = "To_full_pay_contract_credit";
                        SqlCommand cmd = new SqlCommand(take_purse, connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_client", main_user_window.Id_user);
                        cmd.Parameters.AddWithValue("@before", main_user_window.pursee);
                        cmd.Parameters.AddWithValue("@name_oper", "Credit departament");
                        cmd.Parameters.AddWithValue("@after", pu);
                        cmd.Parameters.AddWithValue("@id_service", Id_service);
                        cmd.Parameters.AddWithValue("@pay", pu);                     
                        var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        cmd.ExecuteNonQuery();
                        int result = int.Parse(returnParameter.Value.ToString());
                        if (result != 1)
                            MessageBox.Show("Update don't saved");
                        else
                        {
                            MessageBox.Show("Ok");
                            Purse();
                            refresh();
                                                     
                        }
                    }
                }
                else
            {
                using (SqlConnection connection = new SqlConnection(Hash.connect_str))
                {

                    float pu = main_user_window.pursee - float.Parse(payment.Text);
                    float puu = Debtt - float.Parse(payment.Text.ToString());
                    connection.Open();
                    string take_purse = "To_part_pay_contract_credit";
                    SqlCommand cmd = new SqlCommand(take_purse, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_client", main_user_window.Id_user);
                    cmd.Parameters.AddWithValue("@before", main_user_window.pursee);
                    cmd.Parameters.AddWithValue("@name_oper", "Credit departament");
                    cmd.Parameters.AddWithValue("@after", pu);
                    cmd.Parameters.AddWithValue("@id_service", Id_service);
                    cmd.Parameters.AddWithValue("@debt", puu);
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int result = int.Parse(returnParameter.Value.ToString());
                    if (result != 1)
                        MessageBox.Show("Update don't saved");
                    else
                    {
                        MessageBox.Show("Ok");
                        Purse();
                        refresh();

                    }
                }

            }
            //}
            //catch (Exception n)
            //{
            //    MessageBox.Show("Exception");
            //    payment.Clear();
            //}


        }
    }
}
