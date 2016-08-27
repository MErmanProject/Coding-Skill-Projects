using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_OneZero_Two_Zeros
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var line = "1 8";
            var myarr = line.Split(' ').Select(int.Parse);
            var mylist = new List<string>();
            var count = 0;

            for (int i = 0; i < myarr.ElementAt(1); i++)
            {
                mylist.Add(Convert.ToString(i + 1, 2));
            }

            foreach (string str in mylist)
            {
                var res = str.GroupBy(a => a).Where(a => a.Key == '0').OrderBy(a => a.Key);
                if (res.Count() != 0 && res.ElementAt(0).Count() == myarr.ElementAt(0))
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}