using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace CW_Sum_Strings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             
            Kata.sumStrings("", "5");
        }
    }


    public static class Kata
    {
        public static string sumStrings(string a, string b)
        {
            if (a.Length == 0)
                return b;  //returns the string itself if one of them is empty
            if (b.Length == 0)
                return a;

            var big1 = BigInteger.Parse(a); //otherwise, use the built in BigInteger class in System.Numerics
            var big2 = BigInteger.Parse(b); //parse each to a BigInteger
            var mybig = big1 + big2; //add together

            return mybig.ToString(); //return as a string
        }
    }
}
