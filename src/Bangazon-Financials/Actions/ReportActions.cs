using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Financials
{
    public class ReportActions
    {
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
                StringBuilder buffer = new StringBuilder();
                for (int i = 0; i < 30 - line.ProductName.Count(); i++)
                {
                    buffer.Append(" ");
                }
                Console.WriteLine($"{line.ProductName}{buffer}{line.ProductRevenue}");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }

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
                StringBuilder buffer = new StringBuilder();
                for (int i = 0; i < 30 - line.ProductName.Count(); i++)
                {
                    buffer.Append(" ");
                }
                Console.WriteLine($"{line.ProductName}{buffer}{line.ProductRevenue}");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }

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
                StringBuilder buffer = new StringBuilder();
                for (int i = 0; i < 30 - line.ProductName.Count(); i++)
                {
                    buffer.Append(" ");
                }
                Console.WriteLine($"{line.ProductName}{buffer}{line.ProductRevenue}");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }

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
                StringBuilder buffer = new StringBuilder();
                for (int i = 0; i < 29 - (line.CustomerFirstName.Count() + line.CustomerLastName.Count()); i++)
                {
                    buffer.Append(" ");
                }
                Console.WriteLine($"{line.CustomerFirstName} {line.CustomerLastName}{buffer}{line.ProductRevenue}");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }

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
                StringBuilder buffer = new StringBuilder();
                for (int i = 0; i < 30 - (line.ProductName.Count()); i++)
                {
                    buffer.Append(" ");
                }
                Console.WriteLine($"{line.ProductName}{buffer}{line.ProductRevenue}");
            });
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadLine();
        }
    }
}
