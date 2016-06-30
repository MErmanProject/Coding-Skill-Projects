using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_HowMuch
{
    public partial class CW_HowMuch : Form
    {
        public CW_HowMuch()
        {
            InitializeComponent();
            Carboat.howmuch(1, 100);
        }

        public class Carboat
        {

            public static string howmuch(int m, int n)
            {

                int mymin = 0;
                int mymax = 0;
                int numcars = 0;
                int numboats = 0;
                var result = "[";

                if (m > n)
                {
                    mymin = n;
                    mymax = m;
                }
                else
                {
                    mymin = m;
                    mymax = n;
                }

                for (int i = mymin; i < mymax + 1; i++)
                {
                    if (i > 8) //has to have 9 cars and if he buys them will have 1 dollars left---minimum of 10//Boats has to have 7 with 2 dollars left over, minimum of 9, so we start at 9
                    {
                        numcars = GetCar(i);
                        numboats = GetBoat(i);
                    }

                    if (numcars > 0 && numboats > 0)
                    {
                        result += (string.Format("[M: {0} B: {1} C: {2}]", i, numboats, numcars)); //add each result to the string
                    }


                }

                return result + "]"; //add the ending bracket to format properly

            }
            private static int GetCar(int i)
            {
                int numcars = 0;

                if ((i - 1) % 9 == 0) //i-1 must be divisible by 9 and have a remainder of 0 if he can purchase cars
                    numcars = (i - 1) / 9;

                return numcars;
            }

            private static int GetBoat(int i)
            {
                int numboats = 0;
                if ((i - 2) % 7 == 0) //i-2 must be divisible by 7 and have a remainder of 0 if he can purchase boats
                    numboats = (i - 2) / 7;

                return numboats;

            }
        }

    }
}
