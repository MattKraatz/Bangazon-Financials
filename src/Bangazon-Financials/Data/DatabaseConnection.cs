using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Bangazon_Financials
{

    /**
     * Class: NAME
     * Purpose: DESCRIPTION
     * Author: YOUR NAME
     * Methods:
     *     string DocMe() - description
     */
    public class DatabaseConnection
    {
        public List<Revenue> getWeek()
        {
            var output = new List<Revenue>();

            execute(@"select Id,
                        ProductName,
                        ProductCost,
                        ProductRevenue,
                        ProductSupplierState,
                        CustomerFirstName,
                        CustomerLastName,
                        CustomerAddress,
                        CustomerZipCode,
                        PurchaseDate
                    from Revenue
                    where PurchaseDate BETWEEN DateTime('now','-7 days') AND DateTime('now')",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            output.Add(new Revenue
                            {
                                Id = reader.GetInt32(0),
                                ProductName = reader[1].ToString(),
                                ProductCost = reader.GetInt32(2),
                                ProductRevenue = reader.GetInt32(3),
                                ProductSupplierState = reader[4].ToString(),
                                CustomerFirstName = reader[5].ToString(),
                                CustomerLastName = reader[6].ToString(),
                                CustomerAddress = reader[7].ToString(),
                                CustomerZipCode = reader.GetInt32(8),
                                PurchaseDate = Convert.ToDateTime(reader[9].ToString())
                            });
                        }
                    });

            return output;
        }

        /**
         * Purpose: Execute SQL statement
         * Arguments:
         *     query - workforce database query
         *     Action<SqliteDataReader> handler - callback function to be executed during connection
         * Return:
         *     n/a 
         */
        public void execute(string query, Action<SqliteDataReader> handler)
        {

            SqliteConnection dbcon = new SqliteConnection(@"Data Source=C:\Users\Matt\Documents\Databases\BangazonRevenue.db");

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            dbcmd.Dispose();
            dbcon.Close();
        }
    }
}
