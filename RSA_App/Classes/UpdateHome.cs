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
    public class UpdateHome : INotifyPropertyChanged
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

        // New Database connection
        DBConnect dbUpdateHome = new DBConnect();

        // Create DataTables
        public static DataTable tblMonth = new DataTable();
        DataTable tblYear = new DataTable();
        DataTable tblHoursDebtorYear = new DataTable();

        // Observable collections for Chart series
        public ObservableCollection<ClusteredColumnChartClass> InCollection { get; private set; }
        public ObservableCollection<ClusteredColumnChartClass> OutCollection { get; private set; }
        public ObservableCollection<PieChartClass> HourCollection { get; set; }

        // Series
        public List<CCSeriesData> CCSeries { get; set; }
        public List<PCSeriesData> PCSeries { get; set; }

        //function which determines if all should update or only the months
        public UpdateHome(string strYear, string strMonth, bool bUpdateAll)
        {
            getSqlDataTables(strYear);

            if(bUpdateAll == true)
            {                
                UpdateYear(strYear);
                UpdateClusteredColumnChart();
            }
  
            UpdateMonth(strYear, strMonth);
            UpdatePieChart();
        }

        // Get the Sql Tables
        public void getSqlDataTables(string strYear)
        {
            // Jagged string arrays
            // Parameters for queryUpdateHomeCurrency for tblMonth
            string[][] SqlParametersMonth = new string[2][]
            {
                new string[] { "@Year",  strYear },
                new string[] { "@Group", "month" },
            };

            // Parameters for queryUpdateHomeCurrency for tblYear
            string[][] SqlParametersYear = new string[2][]
            {
                new string[] { "@Year",  strYear },
                new string[] { "@Group", null }
            };

            // Parameters for queryGetWorkedHoursPerDebtor for tblHoursDebtorYear
            string[][] SqlParametersWorkedHours = new string[2][]
            {
                new string[] {"@Year", strYear},
                new string[] {null, null},
            };            

            // Fill DataTables through Sql Queries
            tblMonth = dbUpdateHome.GetSqlTable(SqlString.queryUpdateHomeCurrency, SqlParametersMonth);
            tblYear = dbUpdateHome.GetSqlTable(SqlString.queryUpdateHomeCurrency, SqlParametersYear);
            tblHoursDebtorYear = dbUpdateHome.GetSqlTable(SqlString.queryGetWorkedHoursPerDebtor, SqlParametersWorkedHours);

            // Count the amount of months of selected year are in database
            iMonthCount = tblMonth.Rows.Count;  
        }

        // Update the Chart
        public void UpdateClusteredColumnChart()
        {
            // Define Series List
            CCSeries = new List<CCSeriesData>();

            // Make new Observable Collections for Chart
            InCollection = new ObservableCollection<ClusteredColumnChartClass>();
            OutCollection = new ObservableCollection<ClusteredColumnChartClass>();

            //Take data from the sql table and place in the appropriate locations in the Chart collections
            foreach (DataRow row in tblMonth.Rows)
            {
                InCollection.Add(new ClusteredColumnChartClass { Timespan = (string)row["dbMonth"], InOut = (decimal)row["dbIn"] });
                OutCollection.Add(new ClusteredColumnChartClass { Timespan = (string)row["dbMonth"], InOut = (decimal)row["dbOut"] });
            }

            // Add ObservableCollections to the Series "Inkomen" en "Uitgaven"
            CCSeries.Add(new CCSeriesData() { DisplayName = "Inkomen", Items = InCollection });
            CCSeries.Add(new CCSeriesData() { DisplayName = "Uitgaven", Items = OutCollection });
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

        public void UpdatePieChart()
        {
            PCSeries = new List<PCSeriesData>();
            HourCollection = new ObservableCollection<PieChartClass>();

            foreach(DataRow row in tblHoursDebtorYear.Rows)
            {
                HourCollection.Add(new PieChartClass { Debtor = (string)row["dbDebtor"], Hours = (decimal)row["dbHours"] });
            }

            // Add ObservableCollections to the Series "Inkomen" en "Uitgaven"
            PCSeries.Add(new PCSeriesData() { DisplayName = "WerkUren", Items = HourCollection });
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

    //class for ClusteredColumn ChartData
    public class ClusteredColumnChartClass
    {
        public string Timespan { get; set; }
        public decimal InOut { get; set; }
    }

    //class for Pie ChartData
    public class PieChartClass
    {
        public string Debtor { get; set; }
        public decimal Hours { get; set; }
    }

    //class for ChartSeries
    public class CCSeriesData
    {
        public string DisplayName { get; set; }
        
        public ObservableCollection<ClusteredColumnChartClass> Items { get; set; }
    }

    //class for ChartSeries
    public class PCSeriesData
    {
        public string DisplayName { get; set; }

        public ObservableCollection<PieChartClass> Items { get; set; }
    }   

}
