using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using RSA_App.GUI.UserControls;

namespace RSA_App.Classes
{
    public class UpdateYearMonth : INotifyPropertyChanged
    {   
        object objYearIn;
        object objYearOut;
        object objMonth;
        object objMonthIn;
        object objMonthOut;

        public static int iMonthCount;

        public static string strInYear;
        public static string strTotalYearIn;
        public static string strOutYear;
        public static string strTotalYearOut;
        public static string strInMonth;
        public static string strTotalMonthIn;
        public static string strOutMonth;
        public static string strTotalMonthOut;

        public static string[] strArrMonths;

        // New Database connection
        DBConnect dbUpdateYearMonth = new DBConnect();

        // Create DataTables
        public static DataTable tblMonth = new DataTable();
        DataTable tblYear = new DataTable();

        // Observable collections for Chart series
        public ObservableCollection<ChartClass> InCollection { get; private set; }
        public ObservableCollection<ChartClass> OutCollection { get; private set; }

        //function which determines if all should update or only the months
        public UpdateYearMonth(string strYear, string strMonth, bool bUpdateAll)
        {
            getSqlDataTables(strYear);

            if(bUpdateAll == true)
            {                
                UpdateYear(strYear);
                UpdateMonth(strYear, strMonth);
                UpdateChart();
            }
            else
            {
                UpdateMonth(strYear, strMonth);
            }            
        }

        // Get the Sql Tables
        public void getSqlDataTables(string strYear)
        {
            // Jagged string arrays
            string[][] SqlParametersMonth = new string[2][]
            {
                new string[] { "@Year",  strYear },
                new string[] { "@Group", "month" },
            };

            string[][] SqlParametersYear = new string[2][]
            {
                new string[] { "@Year",  strYear },
                new string[] { "@Group", null }
            };

            // Fill DataTables through Sql Queries
            tblMonth = dbUpdateYearMonth.GetSqlTable(SqlString.queryUpdateHomeCurrency, SqlParametersMonth);
            tblYear = dbUpdateYearMonth.GetSqlTable(SqlString.queryUpdateHomeCurrency, SqlParametersYear);

            // Count the amount of months of selected year are in database
            iMonthCount = tblMonth.Rows.Count;
        }

        // Update the Chart
        public void UpdateChart()
        {
            // Define Series List
            Series = new List<SeriesData>();

            // Make new Observable Collections for Chart
            InCollection = new ObservableCollection<ChartClass>();
            OutCollection = new ObservableCollection<ChartClass>();

            //Take data from the sql table and place in the appropriate locations in the Chart collections
            foreach (DataRow row in tblMonth.Rows)
            {
                InCollection.Add(new ChartClass { Timespan = (string)row["dbMonth"], InOut = (decimal)row["dbIn"] });
                OutCollection.Add(new ChartClass { Timespan = (string)row["dbMonth"], InOut = (decimal)row["dbOut"] });
            }

            // Add ObservableCollections to the Series "Inkomen" en "Uitgaven"
            Series.Add(new SeriesData() { DisplayName = "Inkomen", Items = InCollection });
            Series.Add(new SeriesData() { DisplayName = "Uitgaven", Items = OutCollection });
        }

        //Update the Months
        public void UpdateMonth(string strYear, string strMonth)
        {
            foreach (DataRow row in tblMonth.Rows)
            {
                if (strMonth == (string)row["dbMonth"])
                {
                    objMonth = (string)row["dbMonth"];      // dbMonth
                    objMonthIn = (decimal)row["dbIn"];      // dbIn
                    objMonthOut = (decimal)row["dbOut"];    // dbOut

                    strInMonth = "Maandelijksed Inkomsten \r\n" + objMonth + " " + strYear;
                    strTotalMonthIn = "\u20AC " + String.Format("{0:0,0.00}", objMonthIn);

                    strOutMonth = "Maandelijkse Uitgaven \r\n" + objMonth + " " + strYear;
                    strTotalMonthOut = "\u20AC " + String.Format("{0:0,0.00}", objMonthOut);
                }
            }
        }

        // Update the Years
        public void UpdateYear(string strYear)
        {
            objYearIn = objMonthIn = tblYear.Rows[0][2];    // dbIn
            objYearOut = objMonthOut = tblYear.Rows[0][3];  // dbOut

            strInYear = "Jaarlijkse inkomsten \r\n" + strYear;
            strTotalYearIn = "\u20AC " + String.Format("{0:0,0.00}", objMonthIn);

            strOutYear = "Jaarlijkse uitgaven \r\n" + strYear;
            strTotalYearOut = "\u20AC " + String.Format("{0:0,0.00}", objMonthOut);
        }

        //Series
        public List<SeriesData> Series
        {
            get;
            set;
        }

        //Notify Property Notification
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    //class for ChartData
    public class ChartClass
    {
        public string Timespan { get; set; }
        public decimal InOut { get; set; }
    }

    //class for ChartSeries
    public class SeriesData
    {
        public string DisplayName { get; set; }
        
        public ObservableCollection<ChartClass> Items { get; set; }
    }

}
