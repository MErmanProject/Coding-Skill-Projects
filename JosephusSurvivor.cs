using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_JosephusSurvivor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var myint = 0;
            myint=JosephusSurvivor.JosSurvivor(56, 7);
        }
    }
    public class JosephusSurvivor
    {
        public static int JosSurvivor(int n, int k)
        {

            if (n == 1) //base case
                return 1;
            else //call a recursive function based on the mathematical principles involved.

                return (JosSurvivor(n - 1, k) + k - 1) % n + 1;

        }
    }
}
