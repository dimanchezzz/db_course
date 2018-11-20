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
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : Page
    {
        public Services()
        {
            InitializeComponent();
            RefreshList();
            amount.IsEnabled = false;
           drop.IsEnabled = false;          
        }       
        string depart;
        float perc, termm;
        int rest,id_service, count;

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
                        id_service = int.Parse(reader.GetValue(0).ToString());
                        term.Text = "Term: " + reader.GetValue(2);
                        termm = float.Parse(reader.GetValue(2).ToString());
                        percent.Text = "Percent: " + reader.GetValue(3) + " %";
                        perc = float.Parse(reader.GetValue(3).ToString());
                        restrict.Text = "Restriction: " + reader.GetValue(6);
                        rest = int.Parse(reader.GetValue(6).ToString());
                        date_create.Text = "Date create: " + reader.GetValue(7);
                        comment.Text = "Comment: " + reader.GetValue(8);
                        dep.Text = reader.GetValue(5).ToString();
                        amount.IsEnabled = true;
                    }                
                }
                reader.Close();
              
            }
        }
        private void RefreshList()
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string take = "exec take_name_serv";
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
        public delegate void MethodCHeck();
        public static event MethodCHeck Sent;
        private void pay_calc()
        {
            if (dep.Text == "Credit departament")
            {
                 pay.Text = (float.Parse(amount.Text) / 12 * termm * perc / 100 + float.Parse(amount.Text)).ToString();
               
            }
         else
            {
                float payy = (float.Parse(amount.Text) / 1200 * perc + float.Parse(amount.Text));
                for (int i = 0; i < termm - 1; i++)
                {
                    payy += (payy / 1200 * perc);
                }
                pay.Text = payy.ToString();
            }
        }
        public void go()
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string str = "exec Add_conract_user @id_service=" + id_service + ",@id_client=" + main_user_window.Id_user + @",@status='new',
                            @amount=" + amount.Text + ", @pay=" + pay.Text + ",@debt=" + pay.Text + ";";
                SqlCommand command = new SqlCommand(str, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("You request send;");
                amount.Clear();
                Sent();
                return;
            }
        }
        private void drop_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string str = "select dbo.Take_count_contract ("+ main_user_window.Id_user + ")";
                SqlCommand command = new SqlCommand(str, connection);
               count=int.Parse(command.ExecuteScalar().ToString());
            }
            if (count > 0)
            {
                MessageBox.Show("Request this type already sent");
                Sent();
                return;
            }

                if (dep.Text == "Credit departament")
                {
                    if (int.Parse(amount.Text.ToString()) > rest)
                    {
                        MessageBox.Show("Amount exceeds restriction");
                        amount.Clear();
                    Sent();
                    return;
                    }

                    else
                    {
                    go();
                    }
                }
                else
                {
                if (int.Parse(amount.Text.ToString()) < rest)
                {
                    MessageBox.Show("Amount less than restriction");
                    amount.Clear();
                    Sent();
                    return;
                } else
                {
                    go();
                }


            }          
        }     
        private void amount_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
            if (amount.Text != "")
            {
                pay_calc();
                drop.IsEnabled = true;
            }
                
            else if (amount.Text == "")
            {
                pay.Text = "";
                drop.IsEnabled = false;
            }
                
        }

        private void amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }       
    }
}
