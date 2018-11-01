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
using System.Security.Cryptography;
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
        private void click_reset(object sender, RoutedEventArgs e)
        {
            Password_res pas = new Password_res();
            pas.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (First_model db = new First_model())
            {

                IEnumerable<User_info> users =  db.User_info.Where(u => u.Login.Equals(auto_log.Text));
                if (users.Count() == 0)
                {
                    MessageBox.Show("bad login", "Error");
                    return;
                }
                User_info user = users.FirstOrDefault();
                
                if (user.Password.Equals(Hash.GetHash(auto_pass.Password)))
                {
                    main_user_window man = new main_user_window(user);
                    man.Show();
                    a.Close();
                }
                else
                    MessageBox.Show("bad password","Error");
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
