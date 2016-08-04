using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHandWins
{
    internal class CE_BestHandWins
    {
        private static void Main(string[] args)
        {
            List<Card> myhands = new List<Card>();
            myhands = GetCardStruct("6D 7H AH 7S QC 6H 2D TD JD AS");
            Console.WriteLine(DetermineHandType(myhands));
            myhands = GetCardStruct("6H 7H 9H TH TD 6H 2D TC TS AS");
            Console.WriteLine(DetermineHandType(myhands));
            myhands = GetCardStruct("JH 5D 7H TC JS JD JC TS 5S 7S");
            Console.WriteLine(DetermineHandType(myhands));
            Console.ReadLine();
        }

        //Creates a Card Structure containing the card number and the suit of the card.
        private struct Card
        {
            public int cardnum;
            public char suit;
        }

        //Creates a list of card structures
        private static List<Card> GetCardStruct(string cardstring)
        {
            Array myarr = cardstring.Split(' ');
            List<Card> bothhands = new List<Card>();
            Card mycard = new Card();
            //cycles through the array and assigns str to a card structure and then adds that structure to the list.
            foreach (string str in myarr)
            {
                mycard.cardnum = GetCardNum(str);
                mycard.suit = str[1];
                bothhands.Add(mycard);
            }

            return bothhands;
        }

        //converts CardNum into an integer for comparison ease.  T becomes 10, J becomes 11, Q becomes 12, K becomes 13, A becomes 14
        private static int GetCardNum(string str)
        {
            switch (str[0])
            {
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case 'T': return 10;
                case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                default: return 14;
            }
        }

        //enum with the different types of hands possible ranked 1-10, lowest to highest
        private enum HandType { HighCard = 1, OnePair, TwoPairs, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush }

        //Breaks the string into two separate hands---left hand takes the first 5, right hand takes the last 5.
        private static string DetermineHandType(List<Card> mylist)
        {
            var lefthand = mylist.Take(5).GroupBy(x => x.cardnum).OrderByDescending(y => y.Count()).ThenByDescending(y => y.Key); //takes first 5 items
            var righthand = mylist.Skip(5).GroupBy(x => x.cardnum).OrderByDescending(y => y.Count()).ThenByDescending(y => y.Key); //skips first 5 items

            var leftlist = new List<Card>();
            var rightlist = new List<Card>();

            for (var i = 0; i < 5; i++)
            {
                leftlist.Add(mylist[i]);
                rightlist.Add(mylist[i + 5]);
            }

            return GetWinningHand(leftlist, rightlist, lefthand, righthand);
        }

        //Calls the helper functions to determine what the winning hand is
        private static string GetWinningHand(List<Card> leftlist, List<Card> rightlist, IOrderedEnumerable<IGrouping<int, Card>> lefthand, IOrderedEnumerable<IGrouping<int, Card>> righthand)
        {
            string winninghand = "";
            var leftflush = IsFlush(leftlist);
            var rightflush = IsFlush(rightlist);

            var leftstraight = IsStraight(leftlist);
            var rightstraight = IsStraight(rightlist);

            var lefttype = new HandType();
            var righttype = new HandType();

            //determine if this hand is a straight or a flush
            lefttype = GetStraightorFlushType(lefttype, leftflush, leftstraight, leftlist);
            righttype = GetStraightorFlushType(righttype, rightflush, rightstraight, rightlist);

            //if the handtype is still 0(ie, it's NOT a straight or flush), then get the Type of hand it is based on card matches.
            if (lefttype == 0)
                lefttype = GetSameCardType(lefttype, lefthand);
            if (righttype == 0)
                righttype = GetSameCardType(righttype, righthand);

            winninghand = lefttype > righttype ? "left" : "right";
            winninghand = lefttype == righttype ? BreakTies(lefthand, righthand) : winninghand;

            return winninghand;
        }

        //returns true if all cards are the same suit, false if its not
        private static bool IsFlush(List<Card> mylist)
        {
            //groups by suit and returns true if there is only 1 group(ie, one suit)
            return mylist.GroupBy(x => x.suit).Count() == 1;
        }

        //returns true if the sorted list has a value of 4 when you subtract the last cardnum in the list from the first cardnum
        private static bool IsStraight(List<Card> mylist)
        {
            var mylist2 = mylist.GroupBy(x => x.cardnum).Distinct().OrderBy(y => y.Key);
            if (mylist2.Count() == 5)
                return mylist2.ElementAt(4).Key - mylist2.ElementAt(0).Key == 4;
            else //cannot be a straight since there are not 5 separate card numbers.
                return false;
        }

        //Determines if its a flush or straight and what type of flush or straight
        private static HandType GetStraightorFlushType(HandType myhandtype, bool flushtype, bool straighttype, List<Card> mylist)
        {
            if (flushtype && straighttype && mylist[4].cardnum == 14) //this hand is a royal flush
                myhandtype = HandType.RoyalFlush;
            else if (flushtype && straighttype) //Straight Flush
                myhandtype = HandType.StraightFlush;
            else if (flushtype)
                myhandtype = HandType.Flush; //Flush
            else if (straighttype)
                myhandtype = HandType.Straight; //Straight

            return myhandtype;
        }

        //if its not a straight or flush, this determines what type of hand it is
        private static HandType GetSameCardType(HandType myhandtype, IOrderedEnumerable<IGrouping<int, Card>> myhand)
        {
            switch (myhand.ElementAt(0).Count())
            {
                case 1:
                    myhandtype = HandType.HighCard;
                    break;

                case 2: // if the element at 1 is also 2, this means they have two pairs, otherwise it means they have one pair
                    myhandtype = myhand.ElementAt(1).Count() == 2 ? HandType.TwoPairs : HandType.OnePair;
                    break;

                case 3: //if the element at 1 is 2, that means they have a full house, otherwise it means they have 3 of a kind
                    myhandtype = myhand.ElementAt(1).Count() == 2 ? HandType.FullHouse : HandType.ThreeOfAKind;
                    break;

                default: //Four of a Kind
                    myhandtype = HandType.FourOfAKind;
                    break;
            }
            return myhandtype;
        }

        //Determines the winning hand if there are ties
        private static string BreakTies(IOrderedEnumerable<IGrouping<int, Card>> lefthand, IOrderedEnumerable<IGrouping<int, Card>> righthand)
        {
            for (var i = 0; i < lefthand.Count(); i++)
            {
                if (lefthand.ElementAt(i).Key == righthand.ElementAt(i).Key) //if the keys are equal it means the card numbers are equal...continue to the next one
                    continue;
                else //otherwise, one is greater than the other
                    return lefthand.ElementAt(i).Key > righthand.ElementAt(i).Key ? "left" : "right";
            }
            //got to the end of the list and all cards are equal---return "none"
            return "none";
        }
    }
}