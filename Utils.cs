using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    internal static class Utils
    {
        public static void Header(string[] labels, string divider)
        {
            string header = "";
            for (int i = 0; i < labels.Length; i++)
            {
                if (labels[i] == "Phone")
                {
                    header += $"{labels[i],-10}";
                }
                else header += $"{labels[i],-20}";

                if (i != labels.Length - 1)
                {
                    header += " | ";
                }
            }
            divider = new('─', header.Length + 15);

            Console.WriteLine(header);
            Console.WriteLine(divider);
        }
    }
}
