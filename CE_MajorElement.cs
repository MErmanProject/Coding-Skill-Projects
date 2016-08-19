using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_MajorElement
{
    public class Program
    {
        public static void Main()
        {
            string line = "92,19,19,76,19,21,19,85,19,19,19,94,19,19,22,67,83,19,19,54,59,1,19,19";
            Console.WriteLine(GetMajor(line));
        }

        private static string GetMajor(string line)
        {
            //takes the string and splits it into an array then converts it to an Int before groupin
            var myarr = line.Split(',').Select(int.Parse).GroupBy(a => a).OrderByDescending(b => b.Count());
            var mycount = myarr.Sum(a => a.Count()) / 2;

            if (myarr.ElementAt(0).Count() > mycount)
                return myarr.ElementAt(0).Key.ToString();

            return "None";
        }
    }
}