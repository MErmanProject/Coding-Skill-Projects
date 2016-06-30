using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW_CaesarCipherPart2
{
    public partial class CaeserCipherPart2 : Form
    {
        public CaeserCipherPart2()
        {
            InitializeComponent();
            var myList = new List<string>();
            myList=CaesarTwo.encodeStr("A zsnw khjwsv eq vjwsek mfvwj qgmj xwwl; Ljwsv kgxldq twusmkw...", 8);
            List<string> v = new List<string> { "fgGps zpv cpvrv", "fut boe sjccpo'", "e xsfbuit--gps", "zpv uif tipsft", "b-dspxejoh;" };
            CaesarTwo.decode(myList);
        }
    }
    public class CaesarTwo
    {
        public static List<string> encodeStr(string s, int shift)
        {

            int prefix = (int)s[0];
            int prefix_shift = prefix + shift;
            string encodestring = string.Format("{0}{1}", Convert.ToChar(prefix).ToString(), Convert.ToChar(prefix_shift).ToString());
            encodestring = encodestring.ToLower();
            var encodeList = new List<string>();
           
            Console.WriteLine(s);

            foreach (char c in s) //cycle through the characters
            {
             
                    encodestring += GetChar(c,shift,"encode");
                
            }
            int mylength = encodestring.Length / 5;
            int fifthpiece = encodestring.Length % 5;

            if (encodestring.Length % 5 != 0) //has a remainder
            {
                while (((mylength * 4) + fifthpiece != encodestring.Length) && mylength * 4 < encodestring.Length)
                {
                    mylength += 1;
                    fifthpiece = encodestring.Length - (mylength * 4);
                }


                for (int i = 0; i < encodestring.Length; i++) //checks to see what the greatest number of characters part 5 can be without going over the other parts
                {
                    if ((encodestring.Length - (i * 4) < mylength) && (encodestring.Length - (i * 4) > fifthpiece))
                    {
                        mylength = i;
                        fifthpiece = encodestring.Length - (i * 4);
                    }
                }
            }


            for (int i = 0; i < 5; i++)
            {
                if (i == 4 & fifthpiece != 0)
                    encodeList.Add(encodestring.Substring((i * mylength), (fifthpiece)));
                else if (i < 4)
                    encodeList.Add(encodestring.Substring((i * mylength), mylength));
              
            }
            
            return encodeList;
        }

        public static string decode(List<string> s)
        {
            string decodestring = "";
            string result = "";


            for (int i = 0; i < s.Count; i++) //cycles through the number of lists
            {
                decodestring += s[i].ToString();
            }

            int shift = (int)decodestring[1] - (int)decodestring[0];
            decodestring = decodestring.Remove(0, 2); //removes the first two prefix characters from the message

            foreach (char c in decodestring) //cycles through each character in the string
            {
                result+=GetChar(c, shift,"decode");  //Function call to reuse code for both encoding and decoding            
            }
            return result;
        }
        
        private static char GetChar(char c, int shift, string typeCaeser) //gets the character from the shift
        {
            if (typeCaeser == "decode")
               
                    shift = shift * -1;
                
            if (char.IsLetter(c))
            {
                int myc = c;

                if (char.IsUpper(c))
                {
                    if (myc + shift > 64 && myc + shift < 91)  //checks to make sure the shift is between letters
                     return Convert.ToChar(c + shift);                                            

                    else  //shift goes into other characters, need to start over
                    {
                        myc = (c + shift); //90 is the upper bound in ASCII of the upper case letters
                        if (myc < 65)
                            return Convert.ToChar(myc - 65 + 91);
                        else
                            return Convert.ToChar(myc - 90 + 64);
                    }
                }

                else //if (char.IsLower(c))
                {
                    if (myc + shift > 96 && myc + shift < 123) //check to make sure shift is between the upper and lower bounds of lower case letters
                        
                        return Convert.ToChar(c + shift);  
                        
                    else
                    {                       
                        myc = (c+shift); //123 is the upper bound of the ASCII letters
                        if (myc < 97) //needs to shift to the end of the alphabet
                            return Convert.ToChar(myc - 97 + 123);
                        else //needs to shift to beginning of the alphabet
                            return Convert.ToChar(myc - 122 + 96);
                        
                    }
                }
            }

            else
                return  c;

        }

    }
}
