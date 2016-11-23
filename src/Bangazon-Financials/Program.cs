using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Financials
{
    public class Program
    {

        /**
         * Purpose: Entry-point for program, display Main Menu and control routing
         * Arguments:
         *     none used
         * Return:
         *     void
         */
        public static void Main(string[] args)
        {
            // Variable to contain user selection on Main Menu
            string selection = "";
            while (selection == "")
            {
                // Display Main Menu
                Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================

1. Weekly Report
2. Monthly Report
3. Quarterly Report
4. Customer Revenue Report
5. Product Revenue Report
x. Exit Program");

                // Wait for input
                selection = Console.ReadLine();

                // Exit program
                if (selection.ToLower() == "x")
                {
                    break;
                }

                // Report routing
                switch(selection)
                {
                    case "1":
                        ReportActions.WeeklyReport();
                        break;
                    case "2":
                        ReportActions.MonthlyReport();
                        break;
                    case "3":
                        ReportActions.QuarterlyReport();
                        break;
                    case "4":
                        ReportActions.CustomerReport();
                        break;
                    case "5":
                        ReportActions.ProductReport();
                        break;
                    default:
                        Console.WriteLine("I don't recognize that selection, please try again.");
                        break;
                }
                
                // Reset selection when returning to Main Menu, or if unavailable routing selection was provided
                selection = "";
            }
        }
    }
}
