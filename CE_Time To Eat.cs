using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Time_To_Eat
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var line = "02:26:31 14:44:45 09:53:27";
            var str = "";
            var arr = line.Split(' ');
            var res = arr.OrderByDescending(a => a);

            foreach (var time in res)
            {
                str += time + " ";
            }

            str = str.Trim();

            Console.WriteLine(str);
        }
    }
}