using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;

namespace RSA_App.Classes
{
    class DBConnect
    {
        private MySqlConnection SqlConnection;
        private MySqlCommand SqlCommand;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            SqlConnection = new MySqlConnection(SqlString.ConnString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                SqlConnection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                string exception = "Exception : " + ex.Message.ToString();
                MessageBox.Show(exception, "Kan geen verbinding maken met de RSA database");
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                SqlConnection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                string exception = "Exception : " + ex.Message.ToString();
                MessageBox.Show(exception, "Kan de verbinding met de RSA database niet verbreken");
                return false;
            }
        }

        // Add Parameters to the Query from Jagged Array
        public void AddParameters(string[][] Params)
        {
            SqlCommand.Parameters.Clear();

            if (Params != null)
            {
                for (int iOuterArray = 0; iOuterArray < Params.Length; iOuterArray++)
                {
                    SqlCommand.Parameters.AddWithValue(Params[iOuterArray][0], Params[iOuterArray][1]);
                }
            }
        }

        // Get Sql Table with parameters for Home Currency Query
        public DataTable GetSqlTable(string TableQuery, string[][] Params)
        {
            DataTable SqlTable = new DataTable();

            if (this.OpenConnection() == true)
            {
                SqlCommand = new MySqlCommand(TableQuery, SqlConnection);

                AddParameters(Params);

                MySqlDataReader dataReader = SqlCommand.ExecuteReader();
                SqlTable.Load(dataReader);

                this.CloseConnection();
            }
            return SqlTable;
        }

        // Count statement
        public int Count(string CountQuery, string[][] Params)
        {
            int Count = -1;

            if (this.OpenConnection() == true)
            {
                SqlCommand = new MySqlCommand(CountQuery, SqlConnection);

                AddParameters(Params);

                Count = int.Parse(SqlCommand.ExecuteScalar() + "");
                this.CloseConnection();
            }
            return Count;
        }
    }
}
