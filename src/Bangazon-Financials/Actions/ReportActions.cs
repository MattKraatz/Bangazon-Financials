using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Financials
{

    /**
     * Class: ReportActions
     * Purpose: Provide methods for displaying any available Reports
     * Author: Matt Kraatz
     * Methods:
     *     void WeeklyReport() - Display an itemized list of products sold this week
     *     void MonthlyReport() - Display an itemized list of products sold this month
     *     void QuarterlyReport() - Display an itemized list of products sold this quarter
     *     void CustomerReport() - Display all customers in order of total revenue
     *     void ProductReport() - Display all products, in order of total revenue
     */
    public class ReportActions
    {
        /**
         * Purpose: Display an itemized list of products sold this week
         * Arguments:
         *     void
         * Return:
         *     Retrieves a list of revenue lines from the database,
         *     prints a header and subheader,
         *     prints a list of products and their price,
         *     waits for input before exiting to the menu system
         */
        public static void WeeklyReport()
        {
            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================

WEEKLY REPORT

Product                       Amount
-------------------------------------
");
            var conn = new DatabaseConnection();
            List<Revenue> output = conn.getWeek();
            output.ForEach(delegate (Revenue line)
            {
                string buffer = Buffer.build(line.ProductName.Count());
                Console.WriteLine($"{line.ProductName}{buffer}${line.ProductRevenue}.00");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }


        /**
         * Purpose: Display an itemized list of products sold this month
         * Arguments:
         *     void
         * Return:
         *     Retrieves a list of revenue lines from the database,
         *     prints a header and subheader,
         *     prints a list of products and their price,
         *     waits for input before exiting to the menu system
         */
        public static void MonthlyReport()
        {
            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================

MONTHLY REPORT

Product                       Amount
-------------------------------------
");
            var conn = new DatabaseConnection();
            List<Revenue> output = conn.getMonth();
            output.ForEach(delegate (Revenue line)
            {
                string buffer = Buffer.build(line.ProductName.Count());
                Console.WriteLine($"{line.ProductName}{buffer}${line.ProductRevenue}.00");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }


        /**
         * Purpose: Display an itemized list of products sold this quarter
         * Arguments:
         *     void
         * Return:
         *     Retrieves a list of revenue lines from the database,
         *     prints a header and subheader,
         *     prints a list of products and their price,
         *     waits for input before exiting to the menu system
         */
        public static void QuarterlyReport()
        {
            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================

QUARTERLY REPORT

Product                       Amount
-------------------------------------
");
            var conn = new DatabaseConnection();
            List<Revenue> output = conn.getQuarter();
            output.ForEach(delegate (Revenue line)
            {
                string buffer = Buffer.build(line.ProductName.Count());
                Console.WriteLine($"{line.ProductName}{buffer}${line.ProductRevenue}.00");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }

        /**
         * Purpose: Display all customers in order of total revenue
         * Arguments:
         *     void
         * Return:
         *     Retrieves a list of revenue lines from the database,
         *     prints a header and subheader,
         *     prints a customer names and their total revenue,
         *     waits for input before exiting to the menu system
         */
        public static void CustomerReport()
        {
            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================

CUSTOMER REVENUE REPORT

Customer                      Amount
-------------------------------------
");
            var conn = new DatabaseConnection();
            List<Revenue> output = conn.getByCustomer();
            output.ForEach(delegate (Revenue line)
            {
                string buffer = Buffer.build(line.CustomerFirstName.Count() + line.CustomerLastName.Count() + 1);
                Console.WriteLine($"{line.CustomerFirstName} {line.CustomerLastName}{buffer}${line.ProductRevenue}.00");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }

        /**
         * Purpose: Display all products in order of total revenue
         * Arguments:
         *     void
         * Return:
         *     Retrieves a list of revenue lines from the database,
         *     prints a header and subheader,
         *     prints a a list of products and their total revenue,
         *     waits for input before exiting to the menu system
         */
        public static void ProductReport()
        {
            Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================

PRODUCT REVENUE REPORT

Product                       Amount
-------------------------------------
");
            var conn = new DatabaseConnection();
            List<Revenue> output = conn.getByProduct();
            output.ForEach(delegate (Revenue line)
            {
                string buffer = Buffer.build(line.ProductName.Count());
                Console.WriteLine($"{line.ProductName}{buffer}${line.ProductRevenue}.00");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }
    }
}
