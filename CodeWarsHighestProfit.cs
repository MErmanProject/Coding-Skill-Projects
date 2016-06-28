using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HighestProfit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MinMax.minMax(new int[] { 1, 2, 4, 5, 3 });
        }
    }
    public class MinMax
    {
        public static int[] minMax(int[] lst)
        {
            int min;
            int max;

            Array.Sort(lst); //sort the Array
            min = lst[0]; //min will be the 1st index
            max = lst[lst.Length - 1]; //max will be the last index

            int[] result = { min, max }; //return an array of int {min,max}
            return result;
        }
    }
}
