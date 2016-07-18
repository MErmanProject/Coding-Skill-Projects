using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_TextDollar
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] mystring = { "145", "2430", "11002", "2500654", "100000000", "12347854", "1232234","123432","18","784","9899","1023445",
            "1123","17","990","12435","8764","7789789","3451","234","1234","5468","1234212","6451237","7789423","23234","52976","3445467","12333",
            "1231","454576","12332","12345778","12345","123456","123786","12343566","127975","12331","189869","1223445","1234553","1234556"};
            var mydollar = new TextDollar();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var str in mystring)
            {
                mydollar.ConvertToString(str);
            }
            sw.Stop();

            double bytes = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;

            Console.WriteLine($"This code took {Math.Round(sw.Elapsed.TotalSeconds, 4)} seconds to run and is using {Math.Round(bytes / 1048576, 3)}MB of Memory.");
            Console.ReadLine();
        }
    }

    internal class TextDollar
    {
        private Dictionary<int, string> OnesTens = new Dictionary<int, string>(){
            { 1,"One"},{2,"Two"}, {3,"Three"}, {4,"Four"}, {5,"Five"}, {6,"Six"}, {7,"Seven"}, {8,"Eight"}, {9,"Nine"}, {0,"Zero"}, {10,"Ten"},
            {11,"Eleven"}, {12,"Twelve"}, {13,"Thirteen"}, {14,"Fourteen"}, {15,"Fifteen"}, {16,"Sixteen"}, {17,"Seventeen"}, {18,"Eighteen"},
            {19,"Nineteen"}
        };

        private Dictionary<int, string> TwentyToNinety = new Dictionary<int, string>() {
           {2,"Twenty"}, {3,"Thirty"}, {4,"Forty"}, {5,"Fifty"}, {6,"Sixty"}, {7,"Seventy"}, {8,"Eighty"}, {9,"Ninety"}
        };

        public string ConvertToString(string mystring)
        {
            string str = "";
            string tensstring = "";
            string hundredsstring = "";
            switch (mystring.Length)
            {
                case 1: //Ones
                    str += OnesTens[int.Parse(mystring)];
                    break;

                case 2: //Tens
                    str += GetTens(mystring);
                    break;

                case 3: //Hundreds
                    str += GetHundreds(mystring);
                    break;

                case 4: //Thousands--simply get the single Thousand amount then add hundreds
                    GetHundreds(mystring.Skip(1), out hundredsstring);
                    str += OnesTens[int.Parse(mystring[0].ToString())] + "Thousand" + hundredsstring;
                    break;

                case 5: //TenThousands--simply add Tens+Hundreds
                    GetTens(mystring.Take(2), out tensstring); //linq taking the first 2 digits
                    GetHundreds(mystring.Skip(2), out hundredsstring); //linq skipping the first 2 digits
                    str += tensstring + "Thousand" + hundredsstring;
                    break;

                case 6: //HundredsThousands---simply get hundreds twice, adding in Thousand after the first one
                    GetHundreds(mystring.Take(3), out hundredsstring); //linq taking the first 3 digits
                    str += hundredsstring + "Thousand";
                    GetHundreds(mystring.Skip(3), out hundredsstring); //linq skipping the first 3 digits
                    str += hundredsstring;
                    break;

                case 7: //Millions---simply get single Million, then
                    str += OnesTens[int.Parse(mystring[0].ToString())] + "Million";
                    GetHundreds(mystring.Skip(1).Take(3), out hundredsstring);
                    //evaluates hundredsstring expression and determines what to add---"Zero" if its Zero or "Thousand" otherwise
                    str += hundredsstring + (hundredsstring == "Zero" ? "Zero" : "Thousand");
                    GetHundreds(mystring.Skip(4), out hundredsstring);
                    str += hundredsstring;
                    break;

                case 8: //TensMillions
                    GetTens(mystring.Take(2), out tensstring);
                    GetHundreds(mystring.Skip(2).Take(3), out hundredsstring);
                    //evaluates hundredsstring expression and determines what to add---"Zero" if its Zero or "Thousand" otherwise
                    str += tensstring + "Million" + (hundredsstring + hundredsstring == "Zero" ? "Zero" : "Thousand");
                    GetHundreds(mystring.Skip(5), out hundredsstring);
                    str += hundredsstring;
                    break;

                case 9: //HundredsMillions
                    GetHundreds(mystring.Take(3), out hundredsstring);
                    str += hundredsstring + "Million";
                    GetHundreds(mystring.Skip(3).Take(3), out hundredsstring);
                    //evaluates hundredsstring expression and determines what to add---"Zero" if its Zero or "Thousand" otherwise
                    str += hundredsstring + (hundredsstring == "Zero" ? "Zero" : "Thousand");
                    GetHundreds(mystring.Skip(6), out hundredsstring);
                    str += hundredsstring;
                    break;
            }
            str = str.Replace("Zero", "");
            return str + "Dollars";
        }

        //takes linq expression and uses out variable to return the string representation from method GetTens
        private void GetTens(IEnumerable<char> myenum, out string tensstring)//overloaded method
        {
            string str = "";
            foreach (var c in myenum)
            {
                str += c.ToString();
            }
            if (str != "00")
                tensstring = GetTens(str);
            else
                tensstring = "Zero";
        }

        private string GetTens(string mystring)
        {
            string str = "";

            if (int.Parse(mystring) < 20)
                str += OnesTens[int.Parse(mystring)];
            else if (mystring.EndsWith("0"))
                str += TwentyToNinety[int.Parse(mystring[0].ToString())];
            else
                str += TwentyToNinety[int.Parse(mystring[0].ToString())] + OnesTens[int.Parse(mystring[1].ToString())];

            return str;
        }

        //takes linq expression and uses out variable to return the string representation from method GetHundreds
        private void GetHundreds(IEnumerable<char> myenum, out string hundredsstring) //overloaded method
        {
            string str = "";
            foreach (var c in myenum)
            {
                str += c.ToString();
            }
            if (str != "000")
                hundredsstring = GetHundreds(str);
            else
                hundredsstring = "Zero";
        }

        private string GetHundreds(string mystring) //Converts and hundreds to string representation
        {
            string newstr = mystring[1].ToString() + "" + mystring[2].ToString();
            string str = "";

            if (mystring[0].Equals('0') && mystring[1].Equals('0')) //Its a single digit only
                str += OnesTens[int.Parse(mystring[2].ToString())];
            else if (mystring[0].Equals('0')) //its a ten only
                str += GetTens(newstr);
            else if (int.Parse(newstr) < 20)
                str += OnesTens[int.Parse(mystring[0].ToString())] + "Hundred" + OnesTens[int.Parse(newstr)];
            else if (mystring.EndsWith("0"))
                str += OnesTens[int.Parse(mystring[0].ToString())] + "Hundred" + TwentyToNinety[int.Parse(newstr[0].ToString())];
            else
                str += OnesTens[int.Parse(mystring[0].ToString())] + "Hundred" + TwentyToNinety[int.Parse(mystring[1].ToString())] + OnesTens[int.Parse(mystring[2].ToString())];

            return str;
        }
    }
}