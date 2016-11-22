using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Financials
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var AcceptableInputs = new int[5] { 1, 2, 3, 4, 5 };
            int selection = 0;
            while (!AcceptableInputs.Contains(selection))
            {
                Console.WriteLine(@"
==========================
BANGAZON FINANCIAL REPORTS
==========================

1. Weekly Report
2. Monthly Report
3. Quarterly Report
4. Customer Revenue Report
5. Product Revenue Report
X. Exit Program");

                string input = Console.ReadLine();

                if (input.ToLower() == "x")
                {
                    break;
                }

                try
                {
                    selection = Convert.ToInt32(input);
                }
                catch
                {
                    Console.WriteLine("I don't recognize that selection, please try again.");
                    selection = 0;
                    continue;
                }

                switch(selection)
                {
                    case 1:
                        ReportActions.WeeklyReport();
                        selection = 0;
                        break;
                    case 2:
                        ReportActions.MonthlyReport();
                        selection = 0;
                        break;
                    case 3:
                        ReportActions.QuarterlyReport();
                        selection = 0;
                        break;
                    case 4:
                        ReportActions.CustomerReport();
                        selection = 0;
                        break;
                    case 5:
                        ReportActions.ProductReport();
                        selection = 0;
                        break;
                    default:
                        Console.WriteLine("I don't recognize that selection, please try again.");
                        selection = 0;
                        break;
                }

            }
        }
    }
}
