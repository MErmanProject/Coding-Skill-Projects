using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_PizzaCuts
{
    public partial class CW_PizzaCuts : Form
    {
        public CW_PizzaCuts()
        {
            InitializeComponent();
            Console.WriteLine(Pizza.maxPizza(4));
        }

        public class Pizza
        {

            public static int maxPizza(int cut)
            {
                switch (cut)
                {
                    case 0:               
                       return 1;  //no cuts max is 1                                              
                    default:
                        if (cut < 0)
                            return -1; //a negative number returns -1
                        else
                            return ((cut * cut) + cut + 2) / 2;  //mathematical formula to get most possible cuts                   
                }
            }
        }
    }
}
