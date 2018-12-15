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
using RSA_App.Classes;

namespace RSA_App.GUI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            DBConnect dbLogin = new DBConnect();
            int iLogin = 0;

            // Jagged string array
            string[][] SqlParametersLogin = new string[2][]
            {
                new string[] { "@usr", txtUserName.Text},
                new string[] { "@pwd", txtPassword.Password},
            };

            // Count existence of filled in username and password throug sql query
            iLogin = dbLogin.Count(SqlString.queryLogin, SqlParametersLogin);

            if (iLogin != 0)
            {
                // Get the name from the user for references
                UserName.Login = txtUserName.Text;

                // Hide this form
                this.Hide();

                // Open Dashboard
                Home HomeGUI = new Home();
                HomeGUI.Show();
                this.Hide();
            }
            else
            {
                // show label when login data is not in the database
                MessageBox.Show("Verkeerde invoer, probeer opnieuw...!!");
                txtUserName.Clear();
                txtPassword.Clear();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Wil je het programma sluiten?", "Afsluiten", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
