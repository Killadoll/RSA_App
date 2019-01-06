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

            // Initial start of comboboxen
            cbYear.SelectedIndex = 0;
            strYear = cbYear.SelectedValue.ToString();

            cbMonth.SelectedIndex = 0;
            strMonth = cbMonth.SelectedValue.ToString();

            // Update Chart and currency overview
            UpdateHomeYearChart();            
        }

        // Update all Overviews: Chart, Year and Month
        public void UpdateHomeYearChart()
        {
            // Boolean set to true to update all
            bool bUpdateAll = true;

            // Gather info for Chart and bind to Chart
            ChartBalence.DataContext = new UpdateYearMonth(strYear, strMonth, bUpdateAll);

            // Fill Year-related lables
            lblInYear.Content = UpdateYearMonth.strInYear;
            lblTotalYearIn.Content = UpdateYearMonth.strTotalYearIn;
            lblOutYear.Content = UpdateYearMonth.strOutYear;
            lblTotalYearOut.Content = UpdateYearMonth.strTotalYearOut;

            // Also Update Month
            UpdateHomeMonth();
        }

        // Only Update Month
        public void UpdateHomeMonth()
        {
            // Boolean set to false so only the months will be updated
            bool bUpdateAll = false;

            // Get information for Months
            UpdateYearMonth UpdateAll = new UpdateYearMonth(strYear, strMonth, bUpdateAll);

            // Fill Month related Labels
            lblInMonth.Content = UpdateYearMonth.strInMonth;
            lblTotalMonthIn.Content = UpdateYearMonth.strTotalMonthIn;
            lblOutMonth.Content = UpdateYearMonth.strOutMonth;
            lblTotalMonthOut.Content = UpdateYearMonth.strTotalMonthOut;

            // Fill ComboBox 
            FillcbMonth(UpdateYearMonth.iMonthCount, UpdateYearMonth.tblMonth);
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
            UpdateHomeYearChart();
        }

        // Function when selected item of the Month ComboBox changes
        private void cbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            strMonth = cbMonth.SelectedValue.ToString();
            UpdateHomeMonth();
        }
    }
}
