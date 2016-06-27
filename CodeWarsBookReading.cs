using System;
using System.Windows.Forms;

/*CodeWars Description:
One Sunday Vasya went to a bookshop and bought a new book on sports programming.The book had exactly n pages. Vasya decided to start reading it starting from the next day, that is, from Monday. Vasya's got a very tight schedule and 
for each day of the week he knows how many pages he will be able to read on that day. Some days are so busy that Vasya will have no time to read whatsoever. However, we know that he will be able to read at least one page a week.
Assuming that Vasya will not skip days and will read as much as he can every day, determine on which day of the week he will read the last page of the book.
Input
The input contains:
A single integer: is a number of pages in the book.
Seven non-negative numbers (that do not exceed 1000) represent how many pages Vasya can read on Monday, Tuesday, Wednesday, Thursday, Friday, Saturday and Sunday correspondingly.It is guaranteed that at least one of those numbers is 
larger than zero.
Output
Return a single number — the number of the day of the week, when Vasya will finish reading the book.The days of the week are numbered starting with one in the natural order: Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
Example: 100 15 20 20 15 10 30 45
By the end of Monday and therefore, by the beginning of Tuesday Vasya has 85 pages left. He has 65 pages left by Wednesday, 45 by Thursday, 30 by Friday, 20 by Saturday and on Saturday Vasya finishes reading the book 
(and he also has time to read 10 pages of something else). */

namespace Test
{
    public partial class CodeWarsBookReading : Form
    {
        public CodeWarsBookReading()
        {
            InitializeComponent();
            Book mybook = new Book();
                int pages = 120;
                int[] days = new int[] { 15, 20, 20, 15, 10, 30, 45 };
            mybook.DayIs(pages, days);
        }


    public class Book
        {
            public int DayIs(int pages, int[] days)
            {
                int dayofweek = 0;

                while (pages > 0)
                {
                    pages = pages - days[dayofweek];
                    if (dayofweek == 6 && pages > 0)
                    {
                        dayofweek = 0;
                    }
                 
                    else
                    {
                        dayofweek++;
                    }                   
                    Console.WriteLine(pages);
                    Console.WriteLine(dayofweek);
                }
                Console.WriteLine(dayofweek);
                return dayofweek;

            }
        }
    }
    
}
