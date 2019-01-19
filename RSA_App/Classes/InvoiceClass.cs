using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;

namespace RSA_App.Classes
{
    class InvoiceClass
    {
        int iCountUnsendWeeks = 0;
        int iCheckUnsendHours = 0;
        int currentWeek = (DateTime.Now.DayOfYear / 7) + 1;
        public static int UnsendWeek;
        double dCreditUnsend = 0;

        public static string strUnsendInvoiceList;
        public static string strLinkToNextAction;
        string strExpiresOn;

        DateTime dateToday = DateTime.Today;

        public ObservableCollection<UnsendInvoiceClass> lstUnsend { get; set; }
        public ObservableCollection<UnpaidInvoiceClass> lstUnpaid { get; set; }

        // New Database connection
        DBConnect dbInvoices = new DBConnect();

        public InvoiceClass()
        {
            getUnsendInvoices();
            getUnpaidInvoices();
        }

        public void getUnsendInvoices()
        {
            // Parameters for queryWeeksSinceInvoice
            string[][] SqlParametersUnsend = null;

            // Parameters for queryCheckUnsendHours
            string[][] SqlParametersCheckUnsendHours = new string[2][];

            // Database queryWeeksSinceInvoice: Result is a negative number of weeks since last invoice
            iCountUnsendWeeks = dbInvoices.Count(SqlString.queryWeeksSinceInvoice, SqlParametersUnsend);

            // set date to the first day of the year
            DateTime dt = new DateTime(DateTime.Today.Year, 1, 1);

            lstUnsend = new ObservableCollection<UnsendInvoiceClass>();

            // For each unsend week, determine weeknumber, start and end date and look in the 
            // tblhours if there are any hours present for the unsend invoices
            for (int iCountWeeks = 0; iCountWeeks < (-iCountUnsendWeeks); iCountWeeks++)
            {
                UnsendWeek = currentWeek + iCountUnsendWeeks + iCountWeeks;
                int days = (UnsendWeek - 1) * 7;

                DateTime dt1 = dt.AddDays(days);
                DayOfWeek dow = dt1.DayOfWeek;
                DateTime StartDateOfWeek = dt1.AddDays(-(int)dow);

                DateTime dt2 = dt.AddDays(days);
                DateTime EndDateOfWeek = dt2.AddDays(-(int)dow + 6);

                SqlParametersCheckUnsendHours[0] = new string[] { "@Start", StartDateOfWeek.ToString("yyyy-MM-dd") };
                SqlParametersCheckUnsendHours[1] = new string[] { "@End", EndDateOfWeek.ToString("yyyy-MM-dd") };

                iCheckUnsendHours = dbInvoices.Count(SqlString.queryCheckUnsendHours, SqlParametersCheckUnsendHours);

                if (iCheckUnsendHours == 0) // Geen uren ingevuld
                {
                    strUnsendInvoiceList = "Er zijn geen uren ingevuld voor deze periode";
                    strLinkToNextAction = "Nu uren invullen";
                    // Link naar uren invullen
                }
                else // Wel of gedeeltelijk uren ingevuld
                {
                    strUnsendInvoiceList = "\u20AC " + dCreditUnsend.ToString();
                    strLinkToNextAction = "Nu factuur maken";
                    // link naar factuur maken
                }

                lstUnsend.Add(new UnsendInvoiceClass() { Week = UnsendWeek.ToString(), Status = strUnsendInvoiceList, Action= strLinkToNextAction });
            }
        }

        public void getUnpaidInvoices()
        {
            DataTable tblOpenInvoices = new DataTable();

            tblOpenInvoices = dbInvoices.GetSqlTable(SqlString.queryCheckOpenInvoices, null);

            lstUnpaid = new ObservableCollection<UnpaidInvoiceClass>();

            foreach (DataRow row in tblOpenInvoices.Rows)
            {
               strExpiresOn = row.Field<DateTime>("dbExpiresOn").ToString("dd-MM-yyyy");

                if (DateTime.Parse(strExpiresOn) < dateToday)
                {
                    strExpiresOn = strExpiresOn + "  Vervallen...!!";
                }

                lstUnpaid.Add(new UnpaidInvoiceClass { Invoice = row["dbInvoiceNo"].ToString(),
                                                       Debtor = row["dbDebtor"].ToString(),
                                                       Amount = "\u20AC " + row["dbAmount"].ToString(),
                                                       MaxDate = strExpiresOn } );

                //ListViewItem NewItem = new ListViewItem(row["dbInvoiceNo"].ToString());
                //NewItem.SubItems.Add(row["dbDebtor"].ToString());
                //NewItem.SubItems.Add("\u20AC " + row["dbAmount"].ToString());

                //ListViewItem.ListViewSubItem ExpiresOnItem =
                //    NewItem.SubItems.Add(row.Field<DateTime>("dbExpiresOn").ToString("dd-MM-yyyy"));

                //if (DateTime.Parse(ExpiresOnItem.Text) < dateToday)
                //{
                //    NewItem.UseItemStyleForSubItems = false;

                //    NewItem.SubItems[3].Text = ExpiresOnItem.Text + "  Vervallen...!!";
                //}

                //lstvOpenInvoices.Items.Add(NewItem);
            }
        }
    }

    public class UnsendInvoiceClass
    {
        public string Week { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }

    public class UnpaidInvoiceClass
    {
        public string Invoice { get; set; }
        public string Debtor { get; set; }
        public string Amount { get; set; }
        public string MaxDate { get; set; }
    }
}
