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
using System.Data;
using System.Collections.ObjectModel;
using RSA_App.Classes;

namespace RSA_App.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        string strYear;
        string strMonth;

        public Home()
        {
            InitializeComponent();

            // Initial start of comboBoxen
            cbYear.SelectedIndex = 0;
            strYear = cbYear.SelectedValue.ToString();

            cbMonth.SelectedIndex = 0;
            strMonth = cbMonth.SelectedValue.ToString();

            // Update Chart and currency overview
            UpdateCharts();

            // Get the Current Balance in database
            getCurrentBalanceDB();

            FillListUnsendInvoices();
            FillListUnpaidInvoices();
        }

        // Update all Overviews: Chart, Year and Month
        public void UpdateCharts()
        {
            // Boolean set to true to update all
            bool bUpdateAll = true;

            // Gather info for Chart and bind to ClusteredColumn Chart
            ChartBalence.DataContext = new UpdateHome(strYear, strMonth, bUpdateAll);

            // Gather info for Chart and bind to Pie Chart
            PieChart.DataContext = new UpdateHome(strYear, strMonth, bUpdateAll);
            PieChart.ChartTitle = "Gewerkte Uren " + strYear;

            // Fill Year-related lables
            lblInYear.Content = UpdateHome.strInYear;
            lblTotalYearIn.Content = UpdateHome.strTotalYearIn;
            lblOutYear.Content = UpdateHome.strOutYear;
            lblTotalYearOut.Content = UpdateHome.strTotalYearOut;

            // Also Update Month
            UpdateHomeMonth();
        }

        // Only Update Month
        public void UpdateHomeMonth()
        {
            // Boolean set to false so only the months will be updated
            bool bUpdateAll = false;

            // Get information for Months
            UpdateHome UpdateAll = new UpdateHome(strYear, strMonth, bUpdateAll);

            // Fill Month related Labels
            lblInMonth.Content = UpdateHome.strInMonth;
            lblTotalMonthIn.Content = UpdateHome.strTotalMonthIn;
            lblOutMonth.Content = UpdateHome.strOutMonth;
            lblTotalMonthOut.Content = UpdateHome.strTotalMonthOut;

            // Fill ComboBox 
            FillcbMonth(UpdateHome.iMonthCount, UpdateHome.tblMonth);
        }

        // Fill ComboBox with all the months present in database for selected year
        public void FillcbMonth(int iMonthCounter, DataTable tblMonth)
        {
            string[] strArrTemp = new string[iMonthCounter];

            for (int iCountMonths = 0; iCountMonths<iMonthCounter; iCountMonths++)
            {
                strArrTemp[iCountMonths] = tblMonth.Rows[iCountMonths][0].ToString();
            }

            foreach(ComboBoxItem cbItem in cbMonth.Items)
            {
                string cbItemContent = cbItem.Content.ToString();

                if (Array.Exists(strArrTemp, element=>element == cbItemContent))
                {
                    cbItem.Visibility = Visibility.Visible;
                }
                else
                {
                    cbItem.Visibility = Visibility.Collapsed;
                }
            }
        }

        // Function when selected item of the Year ComboBox changes
        private void cbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strYear = cbYear.SelectedValue.ToString();
            UpdateCharts();
        }

        // Function when selected item of the Month ComboBox changes
        private void cbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strMonth = cbMonth.SelectedValue.ToString();
            UpdateHomeMonth();
        }

        // Function to get the current bank balance in database on last sync date
        private void getCurrentBalanceDB()
        {
            Balance getCurrentBalance = new Balance();

            lblCurrentBalance.Content = "\u20AC " + String.Format("{0:0,0.00}", Balance.dcTotalBalance.ToString());
            lblSyncDate.Content = Balance.strLastBookingDate.ToString();
        }

        // TO DO: Create Actual Function
        // Function to go to the bank balance sync
        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Wil je nu de bankgegevens bij gaan werken?",
                "Database Synchroniseren",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Ga naar balans bijwerken...");
            }
        }

        private void FillListUnsendInvoices()
        {
            InvoiceClass  FillUnsendList = new InvoiceClass();

            for(int iCountUnsendWeeks = 0; iCountUnsendWeeks < FillUnsendList.lstUnsend.Count(); iCountUnsendWeeks++)
            {
                lstvUnsendInvoices.Items.Add(FillUnsendList.lstUnsend[iCountUnsendWeeks]);
            }
            
        }

        private void FillListUnpaidInvoices()
        {
            InvoiceClass FillUnpaidList = new InvoiceClass();

            for (int iCountUnpaidInvoices  = 0; iCountUnpaidInvoices < FillUnpaidList.lstUnpaid.Count(); iCountUnpaidInvoices++)
            {
                lstvUnpaidInvoices.Items.Add(FillUnpaidList.lstUnpaid[iCountUnpaidInvoices]);
            }
        }
    }
}
