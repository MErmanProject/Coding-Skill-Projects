using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindTheCapitals
{
    public partial class FindTheCapitals : Form
    {
        public FindTheCapitals()
        {
            InitializeComponent();
            Kata.Capitals("CodEWaRs");
        }


  public static class Kata
    {
        public static int[] Capitals(string word)
        {
            int index = 0;
            List<int> result = new List<int>(); //creates an empty list

            foreach (char c in word) //cycles through each character
            {
                if (char.IsUpper(c)) //checks to see if the character is UpperCase
                {
                    result.Add(index); //if it is it adds the index to the list
                }
                index++;
            }
            return result.ToArray<int>(); //returns the list as an int []
        }
    }
}
}
