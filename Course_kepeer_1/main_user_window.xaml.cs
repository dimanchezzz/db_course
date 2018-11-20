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
using System.Security.Cryptography;
using MahApps.Metro.Controls;
using System.Data.SqlClient;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для main_user_window.xaml
    /// </summary>
    public partial class main_user_window : MetroWindow
    {
        
        public static int Id_user;
        public static float pursee;
        

        public main_user_window(string a,int Id)
        {      
            InitializeComponent();
            Id_user = Id;
            date.Content = a;
            Question.onNewUser += Closedf; 
                    
            Refresh_Purse();
            Services.Sent += refresh_serv;
            Add_purse.Purse += Refresh_Purse;

        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            main_user.Close();

        }
        private void refresh_serv()
        {
            User.Content = new Services();
        }
      
        private void Mouse_move(object sender, MouseEventArgs e)
        {
            date.FontFamily = new FontFamily("Garamond");
        }

        private void leave(object sender, MouseEventArgs e)
        {
            date.FontFamily = new FontFamily("Italic");
        }

        private void clack(object sender, MouseButtonEventArgs e)
        {
            Question qu = new Question();
            qu.Show();      
        }
        
        private MetroWindow accentThemeTestWindow;       
        private void Stylce()
        {
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }
            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 2.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 2.0;
            accentThemeTestWindow.Show();
        }
        private void Refresh_Purse()
        { 
            
            using (SqlConnection connection = new SqlConnection(Hash.connect_str))
            {
                connection.Open();
                string take_purse = "select dbo.Take_purse("+ Id_user +");";
                SqlCommand take_purse_ = new SqlCommand(take_purse, connection);
                pursee = Convert.ToInt64(take_purse_.ExecuteScalar());
                purse.Content = pursee.ToString();              
            }
            
        }
        private void Closedf()
        {
            Close();
        }
       

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                User.Content = new Calc();
            } catch (Exception m)
            {
                MessageBox.Show("No internet connection");
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            User.Content = new Credit_calc();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            User.Content = new Services();
        }

       

        

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            User.Content = new My_contract();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.Content = new Personal_Area();

        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            User.Content = new Money_transaction();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }
            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 2.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 2.0;
            accentThemeTestWindow.Show();

        }

        private void purse_MouseMove(object sender, MouseEventArgs e)
        {
            purse.FontFamily = new FontFamily("Garamond");
        }

        private void purse_MouseLeave(object sender, MouseEventArgs e)
        {
            purse.FontFamily = new FontFamily("Italic");
        }

        private void purse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Add_purse a = new Add_purse();
            a.Show();
        }
    }
}
