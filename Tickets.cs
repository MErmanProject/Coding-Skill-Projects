using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_MovieTickets
{
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
            Line.Tickets(new int[] { 25, 25, 25, 25, 25, 100, 100 });
        }

        public class Line
        {
            public static string Tickets(int[] peopleInLine)
            {
               int[] change = new int[] { 0, 0, 0 };
               foreach(int cust in peopleInLine)
                {
                    switch(cust)
                    {
                        case 25: //exact change, adds 1 25 in change
                            change[0] += 1;
                            break;

                        case 50: //needs 25 in change
                            if (change[0]<1)
                            {
                                return "NO";
                            }
                            else
                            {
                                change[0] -= 1;
                                change[1] += 1;
                            }
                            break;

                        case 100: //needs 75 in change
                            if (change[0] < 3 || (change[0] < 1 && change[1] <1))
                            {
                                return "NO";
                            }
                            else
                            {
                                if(change[1] < 1) //no 50's, change must be 3 25's
                                {
                                    change[0] -= 3;
                                }
                                else
                                {
                                    change[0] -= 1; // 1 50 and 1 25 in change
                                    change[1] -= 1;
                                }
                            }
                            break;
                    }
                                          

                }
                return "YES";
            }
            
        }
    }
}
