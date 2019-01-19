using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_App.Classes
{
    class Balance
    {
        public static decimal dcTotalBalance;
        public static string strLastBookingDate;

        DBConnect dbUpdateBalance = new DBConnect();

        public Balance()
        {
            GetSqlSumAmount();
            GetSqlLastBookingDate();
        }

        public void GetSqlSumAmount()
        {
            dcTotalBalance = dbUpdateBalance.Sums(SqlString.queryGetBlance);
        }

        public void GetSqlLastBookingDate()
        {
            strLastBookingDate = dbUpdateBalance.LastBookingDate(SqlString.queryLastBookingDate);
        }
    }    
}
