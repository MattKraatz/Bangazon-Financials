using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon_Financials
{
    public class Buffer
    {
        private static int _MenuSize { get; set; } = 30;


        /**
         * Purpose: Return a list of spaces to provide proper column alignment on report pages
         * Arguments:
         *     length - number of spaces required in buffer string
         * Return:
         *     String of spaces to be used in column alignment
         */
        public static string build(int length)
        {
            var output = new StringBuilder();
            for (int i = 0; i < _MenuSize - length; i++)
            {
                output.Append(" ");
            }
            return output.ToString();
        }
    }
}
