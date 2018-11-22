using System;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Data.SqlClient;
using System.Data;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Add_purse.xaml
    /// </summary>
    public partial class Add_purse : MetroWindow
    {
        public Add_purse()
        {
            InitializeComponent();
            but += butto;
            we.IsEnabled = false;
        }
        public void butto()
        {
            if (res.Text == "" || amount.Text == "")
                we.IsEnabled = false;
            else
                we.IsEnabled = true;
                

        }
        
      
        public delegate void MMM();
        public static event MMM but;
        public delegate void MethodCHeck();
        public static event MethodCHeck Purse;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                
                float pu = main_user_window.pursee+ float.Parse(amount.Text);
                connection.Open();
                string take_purse = "Add_purse";
                SqlCommand cmd = new SqlCommand(take_purse, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clieint_id", main_user_window.Id_user);
                cmd.Parameters.AddWithValue("@purse", main_user_window.pursee);
                cmd.Parameters.AddWithValue("@name_oper",   res.Text );
                cmd.Parameters.AddWithValue("@after", pu);
               
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                int result = int.Parse(returnParameter.Value.ToString());
                if (result != 2)
                    MessageBox.Show("Update don't saved");
                else
                {
                    MessageBox.Show("Ok");
                    Purse();
                    Close();
                }
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void res_SelectionChanged(object sender, RoutedEventArgs e)
        {
            but();
        }
    }
}
