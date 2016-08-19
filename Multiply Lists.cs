using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_Lists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var str = "41 21 41 81 76 | 42 40 40 32 50";

            var myarr = str.Split(' ');

            var arr1 = myarr.TakeWhile(a => String.Compare("|", a, true) != 0);
            var arr2 = myarr.SkipWhile(a => String.Compare("|", a, true) != 0).Where(a => a != '|'.ToString());

            str = "";

            var mult = arr1.Zip(arr2, (s, i) => int.Parse(s) * int.Parse(i) + " ");

            foreach (var m in mult)
            {
                str += m;
            }

            str = str.Remove(str.Length - 1);
            Console.WriteLine(str);
        }
    }
}