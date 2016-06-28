using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongestConsecutiveWords
{
    public class LongestConsecutives
    {

        public static String LongestConsec(string[] strarr, int k)
        {
            int numtimes = k;
            string challenge = "";
            string longest = "";
            int count = 0;
            if (strarr.Length == 0 || numtimes == 0) //if the array is empty or consecutive words is 0 then do nothing
            {

            }
            for (int i = 0; i < strarr.Length; i++) //cycle through the loop once
            {
                count = i;
                if (numtimes <= strarr.Length - count) //cannot go past the last index of the array
                {

                    for (int x = 0; x < numtimes; x++) //cycle through the loop until you reach numtimes through
                    {

                        challenge += strarr[count]; //add in the next consecutive element from the array
                        count++; //increment the count
                    }
                    if (challenge.Length > longest.Length) //if the challenge string length is greater than the longest string length
                    {
                        longest = challenge; //longest is updated
                        challenge = "";
                    }
                    else
                    {
                        challenge = "";
                    }
                }
            }
            return longest;
        }
    }
}