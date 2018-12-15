using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_App.Classes
{
    class SqlString
    {
        // Connection String
        public static string ConnString = @"
                server=localhost;user id=root;password=admin;database=rsa
        ";

        // Login command
        public static string queryLogin = @"
                SELECT
                    count(*) as cnt 

                FROM
                    tbluser 

                WHERE
                    username = @usr and password = @pwd
        ";

        // Update Chart and Currency overview
        public static string queryUpdateHomeCurrency = @"
                SELECT  
	                MONTHNAME(BookingDate) as dbMonth, 
                    YEAR(BookingDate) as dbYear,
	                SUM(case when Amount > 0 then Amount else 0 end) as dbIn, 
	                ABS(SUM(case when Amount < 0 then Amount else 0 end)) as dbOut

                FROM 
	                tblbalance

                WHERE
	                YEAR(BookingDate)= @Year

                GROUP BY 
                    YEAR(BookingDate), CASE WHEN
                                    @Group = 'Month'
                                THEN
	                                MONTH(BookingDate)
                                ELSE
                                    ''
                                END
            ";

        // Calculate the amount of weeks since the last invoice
        public static string queryWeeksSinceInvoice = @"
                SELECT 
	                ROUND(DATEDIFF(InvoiceDate, CURDATE())/7 , 0) as dbWeeksDiff
    
                FROM
	                tblinvoices
    
                WHERE InvoiceDate = (	SELECT
							                InvoiceDate
							
						                FROM
							                tblinvoices
							
						                ORDER BY
							                tblInvoiceID DESC LIMIT 1)
                            
                GROUP BY 
	                dbWeeksDiff
            ";

        // Check if datarange unsend invoices is in hours table
        public static string queryCheckUnsendHours = @"
                SELECT
	                IF (COUNT(*) > 0, TRUE, FALSE) as dbHoursExist
    
                FROM
	                tblHours

                WHERE
	                WorkDate >= @Start AND WorkDate <= @End
            ";

        // Check for all open invoices
        public static string queryCheckOpenInvoices = @"
                SELECT 
	                InvoiceNo as dbInvoiceNo,
                    Debtor as dbDebtor,
                    Amount as dbAmount,

                    DATE_ADD(InvoiceDate, interval 30 DAY) as dbExpiresOn
    
                FROM
	                tblinvoices
    
                WHERE Status = '-'
            ";


        // Show invoice list
        public static string queryInvoiceList = @"
                SELECT
                    InvoiceNo as dbInvoiceNo,
	                Debtor as dbDebtor,
	                Amount as dbAmount,
	                Tax as dbTax,
	                DATE(InvoiceDate) as dbInvoiceDate,
                    Status as dbStatus	

                FROM
                    tblinvoices

                ORDER BY 
                    InvoiceNo DESC
            ";

        /*****************************************************************************************/
        // Dummy Queries : To be edited when needed
        public static string InsertQuery = @"
                INSERT INTO 
                    tableinfo (name, age)

                VALUES
                    ('John Smith', '33')
            ";

        public static string UpdateQuery = @"
                UPDATE 
                    tableinfo 

                SET 
                    name='Joe', age='22' 
                WHERE 
                    name='John Smith'
            ";

        public static string DeleteQuery = @"
                DELETE 
                
                FROM 
                    tableinfo 

                WHERE name='John Smith'
            ";

        public static string CountQuery = @"
                SELECT 
                    Count(*)

                FROM 
                    tableinfo
            ";
    }
}
