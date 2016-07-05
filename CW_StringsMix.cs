using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CW_Strings_Mix
{
    public partial class CW_StringsMix : Form
    {
        public CW_StringsMix()
        {            
            InitializeComponent();
            Mixing.Mix("Are they here", "yes, they are here");
            Mixing.Mix("looping is fun but dangerous", "less dangerous than coding");
            Mixing.Mix("codewars", "codewars");
            Mixing.Mix("A generation must confront the looming ", "codewarrs");
            Mixing.Mix("Lords of the Fallen", "gamekult");
            Mixing.Mix(" In many languages", " there's a pair of functions");
        }
    }

    /* This is my first attempt at using LINQ to solve coding issues...from this point forward I will be using LINQ by default even when other ways might be simpler or faster
so I can learn it and use it easily for more challenging problems in the future. */

public class Mixing
    {
        public static string Mix(string s1, string s2)
        {
            string mystring = "";

            var s1_query = //gets the characters that are lower case--grouped by character and count>1
                from ch in s1
                where Char.IsLower(ch)
                group ch by ch into g
                where g.Count() > 1
                orderby g.Key
                orderby g.Count()
                select new { g.Key, count = g.Count(), fromlist = 1 };

            var s2_query = //gets the characteres that are lower case--grouped by character and count >1
                from ch in s2
                where Char.IsLower(ch)
                group ch by ch into g
                where g.Count() > 1
                orderby g.Count(), g.Key
                select new { g.Key, count = g.Count(), fromlist = 2 };

            /*joins the queries together, orders them appropriately other than when both lists contains the same count of letters and then groups
            them by a method that is easily turned into an appropriate string value for each(ex: n:1:6-2:4 where 'n' is the character, '1' is the
            first list, '6' is the number of times it appears in the first list, '-'breaks up the lists, '2' is the second list and '4' is the
            number of times it appears in the second list. Done this way mostly for my readability*/
            var myjoin =
                 s1_query.Concat(s2_query)
                .OrderByDescending(item => item.count).ThenBy(item => item.fromlist).ThenBy(item => item.Key)
                .GroupBy(item => item.Key, item => item.fromlist + ":" + string.Join(",", item.count), (key, values) => key + ":" + string.Join("-", values));

            if (myjoin.Count() == 0) //there are no differences between the strings, return an empty string
                mystring = "";
            else
            {
                foreach (var entry in myjoin) //cycle through each entry
                {
                    if (entry.Length > 5) //both lists contain this element(entries with only 1 list are 5 characters long)
                    {
                        if (entry[4] > entry[8] || entry[4] < entry[8]) //compares the count between times it appears in list 1 and list 2---the correct one will always be first because of the orderby                    
                            mystring += $"{entry[2]}:{string.Concat(Enumerable.Repeat(entry[0], int.Parse(entry[4].ToString())))}/";
                        else //entries appear in both lists the same number of times--change the list number to a '='
                            mystring += $"=:{string.Concat(Enumerable.Repeat(entry[0], int.Parse(entry[4].ToString())))}/";
                    }
                    else //the entry only appears in one list
                        mystring += $"{entry[2]}:{string.Concat(Enumerable.Repeat(entry[0], int.Parse(entry[4].ToString())))}/";

                }
                mystring = mystring.Remove(mystring.Length - 1); //removes the trailing '/' to prevent an empty string being added to the list    
                var string2 = mystring.Split('/').ToList();  //splits by the '/' and creates a list  

                /*redoes the ordering with the elements now having the proper syntax, orders by element length, then index 0
                which is the list that had the most of these characters(1,2 or =), then by index 2, which is the character, and then
                adds the '/' back onto the end of the element in the select statment */

                var mylist = string2
                    .OrderByDescending(a => a.Length).ThenBy(a => a[0]).ThenBy(a => a[2]).ToList()
                    .Select(x => x + "/");

                mystring = ""; //resets to empty for re-use
                foreach (var entry in mylist) //cycles through each element in mylist
                {
                    mystring += entry.ToString(); //adds it to the string
                }
                mystring = mystring.Remove(mystring.Length - 1); //removes the final '/'

            }
            return mystring;
        }
    }
}
