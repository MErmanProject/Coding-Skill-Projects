using System;
using System.Windows.Forms;

namespace FizzBuzzinC_Sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i=0; i<101; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
        }
        private string FizzBuzz(int num) 
        {
            string mystring;
            if (num % 5 == 0 && num % 3 == 0)
            {
                mystring = "FizzBuzz";
            }
            else if (num % 3 == 0)
            {
                mystring = "Fizz";
            }
            else if (num % 5 == 0)
            {
                mystring = "Buzz";
            }
            else
                mystring = num.ToString();

            return mystring;
        }
            

    }
}
