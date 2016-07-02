using System;
using System.Collections.Generic;

    public partial class RomanNumeralDecoder 
	{
	     public static void Main()
	     {
            	RomanDecode.Solution("MMVIII");
             }
        }

    public class RomanDecode
    {
        public static int Solution(string roman)
        {
            Dictionary<string, int> mydict = new Dictionary<string, int>(); //creates a dictionary object to hold Roman Numerals string as Keys and integer as values
            int number = 0;
            int startcount = 0;
            int endcount = 1;
            
            mydict.Add("I", 1);   //add in the base Roman Numerals all others are built from      
            mydict.Add("V", 5);
            mydict.Add("X", 10);
            mydict.Add("L", 50);
            mydict.Add("C", 100);
            mydict.Add("D", 500);
            mydict.Add("M", 1000);        
         
            if (roman.Length==1) //return the number itself
              return mydict[roman[startcount].ToString()];
            
            while (endcount <= roman.Length-1) //cycles through the string
            {
				
                if (mydict[roman[startcount].ToString()] >= mydict[roman[endcount].ToString()]) //if the value of the first number is bigger than the second number
				
                {
                    number+=mydict[roman[startcount].ToString()]; //just add the first number
										
                    if (startcount != endcount) //if the end of the string hasn't been reached
                    	startcount++;
		    else
                        return number; //end is reached, return answer
						          					
		    if (endcount !=roman.Length-1) //if the end of the string has not been reached
                    	endcount++;				
                }             
								
                while ((mydict[roman[startcount].ToString()] < mydict[roman[endcount].ToString()]) && (endcount <= roman.Length-1)) //the number is less then the one after it, ie, IX
                { 			                                        
                    number += Math.Abs(mydict[roman[startcount].ToString()] - mydict[roman[endcount].ToString()]); //subtracts the first number from the second number and used the absolute value function to remove any negative, then adds it to the number				                                        
                    
                    if (endcount == roman.Length-1) //if the end is equal to the length of the roman numberal string then exit
		         return number; //end is reached, return answer
		    else 
		    {
  		         startcount+=2; //must jump ahead 2 because you are comparing the next 2 numbers
	                 endcount+=2;
		    }
                }
            }
            return number;
        }
    }