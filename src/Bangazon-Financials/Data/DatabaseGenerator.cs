using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Bangazon_Financials
{
    /**
     * Class: DatabaseGenerator
     * Purpose: Build and execute SQL commands to generate a Revenue table and populate it with randomized data
     * Author: Matt Kraatz
     * Methods:
     *     string RandomizeCustomerProducts() - Provide an insert commands with randomized product data
     *     string RandomizeCustomerProducts(int numOfEntries) - Build a string of insert commands with randomized products
     *     void CreateDatabase() - Execute SQL commands to create a Revenue table in a database
     *     
     */
    public class DatabaseGenerator
    {
        Random rnd = new Random();

        // Arrays of acceptable values to be added to product revenue lines at random
        string[] customers = new[] { "Carys", "Emmett", "Latoya", "Trina", "Kade", "Torin", "Aggie", "Caelan", "Patsy", "Bettina", "Hans", "Leda", "Clair", "Evan", "Roscoe", "Sondra", "Dixon", "Gail" };
        string[] customersLastName = new[] { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin" };
        string[] products = new[] { "Rug", "Wine Glasses", "Book Ends", "Picture Frame", "Blu-Ray Player", "Digital Camera", "Stuffed Animal - Monkey", "Stuffed Animal - Sloth", "Spatula", "Crayons", "Headphones", "Lawn Furniture", "Hammer", "Computer Monitor", "Golf Clubs", "Raspberry Pi", "eReader" };
        int[] productprice = new[] { 57, 21, 16, 22, 95, 257, 4, 5, 10, 2, 53, 150, 25, 950, 860, 45, 250 };
        int[] productrevenue = new[] { 3, 1, 4, 2, 15, 52, 1, 1, 1, 1, 5, 53, 3, 24, 169, 10, 9 };
        string[] customerAddressNumbers = new[] { "123", "435", "44", "283a", "6b", "1440", "7723", "289", "7564", "985-b", "33922", "23", "546", "5692", "6780", "9362", "121", "74567", "18", "9" };
        string[] customerAddressStreet = new[] { "Mallory Lane", "Carothers Pkwy", "Claybrook Lane", "Bending Creek Drive", "Old Hickory Blvd", "Harris Ave", "21st Ave N", "Plus Park Blvd", "Interstate Blvd S", "Whitney Ave", "Bell Rd", "Harding Pky", "Nolesville Road", "Charlotte Ave" };
        int[] customerZipcode = new int[] { 37013, 37072, 38461, 37115, 37116, 37201, 37211, 37216, 37222 };
        string[] supplierState = new string[] { "AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HA", "ID", "IL", "IN", "IA", "KA", "KY", "LA", "ME", "MD", "MS", "MC", "MN", "MI", "MO", "MT", "NB", "NV", "NH", "NJ", "NC", "NY", "NM", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "WA", "WV", "WI", "WY" };


        /**
         * Purpose: Provide an insert commands with randomized product data
         * Arguments:
         *     void
         * Return:
         *     Insert commands with randomized product data
         */
        public string RandomizeCustomerProducts()
        {
            // Generate random numbers within an acceptable range for each product property
            var rnd1 = rnd.Next(customers.Length);
            var rnd2 = rnd.Next(customersLastName.Length);
            var rnd3 = rnd.Next(products.Length);
            var rnd4 = rnd.Next(customerAddressNumbers.Length);
            var rnd5 = rnd.Next(customerAddressStreet.Length);
            var rnd6 = rnd.Next(customerZipcode.Length);
            var rnd7 = rnd.Next(supplierState.Length);

            int range = 200;
            DateTime start = DateTime.Today.AddDays(-range);

            // Build the insert command string
            string command = $@"
        INSERT INTO Revenue 
        VALUES (
            null,
            '{products[rnd3]}', 
            {productprice[rnd3]}, 
            {productrevenue[rnd3]}, 
            '{supplierState[rnd7]}', 
            '{customers[rnd1]}', 
            '{customersLastName[rnd2]}', 
            '{customerAddressNumbers[rnd4]} {customerAddressStreet[rnd5]}', 
            {customerZipcode[rnd6]}, 
            '{start.AddDays(rnd.Next(range)).ToString("yyyy-MM-dd HH:mm:ss")}'
        );";

            return command;
        }


        /**
         * Purpose: Build a string of insert commands with randomized products
         * Arguments:
         *     numOfEntries - number of rows to create in the database
         * Return:
         *     Strong of insert commands with randomized products
         */
        public string RandomizeCustomerProducts(int numOfEntries)
        {
            string returnstring = "";
            for (var i = 0; i < numOfEntries; i++) { returnstring += RandomizeCustomerProducts(); }
            return returnstring;
        }

        /**
         * Purpose: Execute SQL commands to create a Revenue table in a database
         * Arguments:
         *     void
         * Return:
         *     void
         */
        public void CreateDatabase()
        {
            // SQL commands for creating the Revenue table and adding randomized rows
            string sql = "CREATE TABLE Revenue (" +
                                "[Id] INTEGER NOT NULL CONSTRAINT \"PK_Revenue\" PRIMARY KEY AUTOINCREMENT, " +
                                "[ProductName] TEXT NOT NULL, " +
                                "[ProductCost] INTEGER NOT NULL," +
                                "[ProductRevenue] INTEGER NOT NULL, " +
                                "[ProductSupplierState] TEXT NOT NULL, " +
                                "[CustomerFirstName] TEXT NOT NULL, " +
                                "[CustomerLastName] TEXT NOT NULL, " +
                                "[CustomerAddress] TEXT NOT NULL, " +
                                "[CustomerZipCode] INTEGER NOT NULL, " +
                                "[PurchaseDate] TEXT NOT NULL DEFAULT (strftime('%Y-%m-%d %H:%M:%S')) " +
                            "); "
                            + RandomizeCustomerProducts(1000);

            // Path to the database file on your system
            var connectionString = @"Filename=C:\Users\Matt\Documents\Databases\BangazonRevenue.db";

            SqliteConnection connection = new SqliteConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
