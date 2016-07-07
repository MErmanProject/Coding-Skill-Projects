using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoSum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Tuple<int, int> indices = TwoSum.FindTwoSum(new List<int>() { 1, 3, 5, 2, 4, 5, 8, 5, 7, 6, 5, 54 }, 61);
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
    }

    class TwoSum
    {
        public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {
            //var secondint=0;
            var listpos = 0;
            var count = 0;
            var myint1 = 0;
            var myint2 = 0;
            var mysol = //use linq to create 2 variables to cycle through the list, then use a lamba expression to get the appropriate values
               list
               .SelectMany((mynum1) => list.Select((mynum2) => new { n1 = mynum1, n2 = mynum2}))
               .Where(a => a.n1 + a.n2 == sum );

            foreach (var x in mysol) //get the variables for ease of use
            {
                myint1 = x.n1;
                myint2 = x.n2;
            }

            var mytuple = new Tuple<int, int>(myint1, myint2); //since Tuple is immutable, it must be initiated with the appropriate value
            return mytuple;
        }
    }
}

