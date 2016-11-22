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

            execute(@"select ProductName,
                        ProductRevenue,
                        PurchaseDate
                    from Revenue
                    where PurchaseDate BETWEEN DateTime('now','-7 days') AND DateTime('now')
                    order by PurchaseDate desc",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            output.Add(new Revenue
                            {
                                ProductName = reader[0].ToString(),
                                ProductRevenue = reader.GetInt32(1),
                                PurchaseDate = Convert.ToDateTime(reader[2].ToString())
                            });
                        }
                    });

            return output;
        }

        public List<Revenue> getMonth()
        {
            var output = new List<Revenue>();

            execute(@"select ProductName,
                        ProductRevenue,
                        PurchaseDate
                    from Revenue
                    where PurchaseDate BETWEEN DateTime('now','-1 month') AND DateTime('now')
                    order by PurchaseDate desc",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            output.Add(new Revenue
                            {
                                ProductName = reader[0].ToString(),
                                ProductRevenue = reader.GetInt32(1),
                                PurchaseDate = Convert.ToDateTime(reader[2].ToString())
                            });
                        }
                    });

            return output;
        }


        public List<Revenue> getQuarter()
        {
            var output = new List<Revenue>();

            execute(@"select ProductName,
                        ProductRevenue,
                        PurchaseDate
                    from Revenue
                    where PurchaseDate BETWEEN DateTime('now','-3 months') AND DateTime('now')
                    order by PurchaseDate desc",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            output.Add(new Revenue
                            {
                                ProductName = reader[0].ToString(),
                                ProductRevenue = reader.GetInt32(1),
                                PurchaseDate = Convert.ToDateTime(reader[2].ToString())
                            });
                        }
                    });

            return output;
        }

        public List<Revenue> getByCustomer()
        {
            var output = new List<Revenue>();

            execute(@"select CustomerFirstName,
	                        CustomerLastName,
	                        Sum(ProductRevenue) as 'TotalRevenue'
                        from Revenue
                        group by CustomerFirstName || CustomerLastName
                        order by TotalRevenue desc",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            output.Add(new Revenue
                            {
                                CustomerFirstName = reader[0].ToString(),
                                CustomerLastName = reader[1].ToString(),
                                ProductRevenue = reader.GetInt32(2)
                            });
                        }
                    });

            return output;
        }

        public List<Revenue> getByProduct()
        {
            var output = new List<Revenue>();

            execute(@"select ProductName,
	                        Sum(ProductRevenue) as 'TotalRevenue'
                        from Revenue
                        group by ProductName
                        order by TotalRevenue desc",
                    (SqliteDataReader reader) =>
                    {
                        while (reader.Read())
                        {
                            output.Add(new Revenue
                            {
                                ProductName = reader[0].ToString(),
                                ProductRevenue = reader.GetInt32(1)
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
