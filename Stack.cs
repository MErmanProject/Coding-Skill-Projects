using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StackImplementation
{
    public partial class Stack : Form
    {
        public Stack()
        {
            InitializeComponent();
            string[] myarray = { "0", "2", "3", "4", "5", "6", "7", "8", "9", "12", "43", "15", "25" };
            var MyImp = new MyInterfaceImplementation();

            MyImp.GetFileContent(myarray);
        }
    }

    public interface MyStack
    {
        void Push(string[] mystring);

        string Pop();
    }

    public class MyInterfaceImplementation : MyStack
    {
        private Stack<string> mystack = new Stack<string>();

        public void GetFileContent(string[] myarray)
        {
            Push(myarray);
            Console.WriteLine(Pop());
        }

        public string Pop()
        {
            string mystring = "";
            int count = 0;
            int stackcount = mystack.Count();
            for (int i = 0; i < stackcount; i++)
            {
                if (count % 2 == 0)
                    mystring += mystack.Pop() + " ";
                else
                    mystack.Pop();
                count++;
            }
            return mystring;
        }

        public void Push(string[] mystring)
        {
            foreach (var str in mystring)
            {
                mystack.Push(str);
            }
        }
    }
}