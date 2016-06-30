using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_WhichAreIn
{
    public partial class CW_WhichAreIn : Form
    {
        public CW_WhichAreIn()
        {
            InitializeComponent();
            string[] a1 = new string[] { "arp", "live", "strong" };
            string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };

            WhichAreIn.inArray(a1, a2);
        }

        class WhichAreIn
        {
            public static string[] inArray(string[] array1, string[] array2)
            {
                var myint = array1.Length;
                var result = new List<string>();

                var count = 0;

                foreach (string s in array1) //cycles through each string in array1
                {
                    foreach (string s1 in array2) //cycles through each string in array2
                    {
                        if (s1.Contains(s) && !result.Contains(s)) //if s is in s1 and not in result then add it to the list
                            result.Add(s);

                    }
                    count++;
                }
                string[] resultStrArr = result.ToArray(); //use a list to automatically size the array to avoid NULL values

                Array.Sort(resultStrArr); //sorts the array lexographically

                return resultStrArr;
            }
        }
    }
}
