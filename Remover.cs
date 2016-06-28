using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remover
{
    public partial class Remover : Form
    {
        public Remover()
        {
            InitializeComponent();

            RemoveSmallest(new List<int> { 2, 2, 1, 2, 1 });
        }
            public static List<int> RemoveSmallest(List<int> numbers)
            {
                List<int> myList = new List<int>();
                int index = 0;
                myList = numbers;

                if (myList.Count > 0) //only remove index if list has elements
                {
                    index = myList.IndexOf(myList.Min()); //sets the index to the first minimum element
                    myList.RemoveAt(index);   //removes the index of the minimum element         
                }
                return myList; //returns the list
            }
    }

}





