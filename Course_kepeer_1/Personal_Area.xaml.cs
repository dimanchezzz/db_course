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

namespace Course_kepeer_1
{
    /// <summary>
    /// Логика взаимодействия для Personal_Area.xaml
    /// </summary>
    public partial class Personal_Area : Page
    {
        public Personal_Area()
        {
            InitializeComponent();
        }

        private void agree_Click(object sender, RoutedEventArgs e)
        {
            info_panel.IsEnabled = true;

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            info_panel.IsEnabled = false;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
