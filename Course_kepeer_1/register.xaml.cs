using System;
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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для register.xaml
    /// </summary>
    /// 
    
    public partial class register : Page, INotifyPropertyChanged
    {
        public static string pattern = @"[^0-9a-zA-Z_-]+";
        public register()
        {
            InitializeComponent();
            DataContext = this;          
        }     
        private void Click_agreement(object sender, MouseButtonEventArgs e)
        {
            Agree ag = new Agree();
            ag.Show();
            
        }
        private void TextBlock_MouseMove(object sender, MouseEventArgs e)
        {
            agreement.FontSize = 15;
        }
        private void agreement_MouseLeave(object sender, MouseEventArgs e)
        {
            agreement.FontSize = 12;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public delegate void MethodContainer();
        public static event MethodContainer onregClick;
        private void registers_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(log) == true || Validation.GetHasError(pw1) || Validation.GetHasError(pw2) || Validation.GetHasError(qu) || Validation.GetHasError(ans))
            {
                MessageBox.Show("Incorrectly filled data!");
                return;
            }
            else if (pw1.Password!=pw2.Password)
            {
                MessageBox.Show("Passwords do not match!");
                pw1.Clear();
                pw2.Clear();
                return;
            }         
            else if (Regex.IsMatch(log.Text, pattern))
            {
                MessageBox.Show("Invalid login format");
                log.Clear();
                return;
            }
            else if (Regex.IsMatch(pw1.Password, pattern))
            {
                MessageBox.Show("Invalid password format");
                pw1.Clear();
                pw2.Clear();
                return;
            }
            using (First_model db = new First_model())
            {
                IEnumerable<User_info> users = db.User_info.Where(u => u.Login.Equals(log.Text));
                if (users.Count() > 0)
                {
                    MessageBox.Show("Login already exists", "Error");
                    return;
                }
                else
                    try                  
                    {
                    User_info User1 = new User_info
                    {
                        Login = log.Text,
                        Password = Hash.GetHash(pw1.Password),
                        Question = qu.Text,
                        Answer = Hash.GetHash(ans.Text)
                    };
                    db.User_info.Add(User1);
                    db.SaveChanges();
                    MessageBox.Show("ok", "Message");
                        onregClick();                  
                }
                catch (Exception)
                {
                    MessageBox.Show("Incorrectly filled data");
                }
            }
        }
        private void check_Checked(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked == true)
            {
                registers.IsEnabled = true;
                return;
            }
        }
        private void check_Unchecked(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked == false)
            {
                registers.IsEnabled = false;
                return;
            }
        }
        private void log_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }
        }
        private void pw1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
