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
using RSA_App.GUI.UserControls;
using RSA_App.Classes;

namespace RSA_App.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Dummy:
            UserName.Login = "Natasja";

            lblUser.Content = "Gebruiker: " + UserName.Login;
        }

        private void HamburgerMenuItem_Selected(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Home());
        }

        private void HamburgerMenuItem_Selected_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Invoices());
        }
    }
}
