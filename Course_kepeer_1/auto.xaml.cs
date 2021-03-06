﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Data.SqlClient;
namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для auto.xaml
    /// </summary>
    public partial class auto : Page, INotifyPropertyChanged
    {       
        Window a;
        public auto(Window o)
        {
            InitializeComponent();
            a = o;
            DataContext = this;
        }
       
      private void  Button_Click(object sender, RoutedEventArgs e)
        {

            string sqlExpression = "select dbo.auto_user('"+auto_log.Text +"', '"+auto_pass.Password+"');" ;
            string take_id = " select dbo.Take_id('"+auto_log.Text+"');";
            string take_status = "select Bank_DB.dbo.IsStatus('" + auto_log.Text + "')";
          
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
               connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                Int32 number = Convert.ToInt32(command.ExecuteScalar());
               if (number==0)
                {
                    MessageBox.Show("invalid Data");
                    auto_log.Clear();
                    auto_pass.Clear();
                }
               else if (number==1)
                {
                    SqlCommand take_id_ = new SqlCommand(take_id, connection);
                    SqlCommand take_statu = new SqlCommand(take_status, connection);
                    int status = Convert.ToInt32(take_statu.ExecuteScalar());
                    int id= Convert.ToInt32(take_id_.ExecuteScalar());
                    
                    string login = auto_log.Text;
                    main_user_window man = new main_user_window(login,id,status);
                    man.Show();
                    a.Close();

                }

            }                      
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        private void Enter(object sender, KeyEventArgs e)
        {
           // if (e.Key == Key.Enter) ;
               
        }
        private void auto_log_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }

        }

        private void auto_pass_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
          

        }
    }
}
