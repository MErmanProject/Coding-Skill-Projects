using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Size_Sub_Array
{
    internal class TwoArraysMedian
    {
        private static void Main(string[] args)
        {
            Solution mysol = new Solution();
            int[] myint1 = { 1, 2, 3 };
            int[] myint2 = { 4, 5, 6 };
            mysol.FindMedianSortedArrays(myint1, myint2);
        }
    }

    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> mylist = new List<int>(); //changes it to a List to take advantage of its built in sorting function
            mylist.AddRange(nums1);  //adds the arrays by range
            mylist.AddRange(nums2);
            mylist.Sort(); //sorts the arrays

            return FindMed(mylist);
        }

        private static double FindMed(List<int> mylist)
        {
            double result;
            //to find the median we need to look at the length of the array. If its odd, the median will be a single value
            //if its even, the median will be the average of the two middle values.
            if (mylist.Count == 1)
                result = mylist[0];
            else
                result = mylist.Count % 2 == 0 ? (double)(mylist[mylist.Count / 2] + mylist[(mylist.Count / 2) - 1]) / 2 :
                                                (double)mylist[(mylist.Count / 2)];

            return result;
        }
    }
}