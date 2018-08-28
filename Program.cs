using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        public static Random rnd = new Random();
        public static List<string> comp = new List<string>();
        public static List<string> player = new List<string>();
        public static string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        static void Main(string[] args)
        {
            Console.WriteLine("Computer cards: {0} {1} => {2}", getCard(comp), getCard(comp), getSum(comp));
            Console.WriteLine("Player cards: {0} {1} => {2}", getCard(player), getCard(player), getSum(player));
            addCards();

            Console.ReadKey();
        }

        public static string getCard(List<string> arr)
        {
            var choice = rnd.Next(0, 13);
            arr.Add(cards[choice]);
            return cards[choice];
        }
        public static int getSum(List<string> arr)
        {
            int sum = 0;
            foreach(var card in arr)
            {
                sum += Array.IndexOf(cards, card) + 2;
            }
            return sum;
        }

        public static void printCards(List<string> arr, string name)
        {
            Console.Write("\n{0} cards: ", name);
            foreach (var card in arr)
            {
                Console.Write(card + " ");
            }
            Console.Write("=> {0}\n", getSum(arr));
        }

        public static string checkCards()
        {


            return "";
        }


        public static void addCards()
        {
            bool p, c;
            p = c = true;
            while (c || p)
            {
                if (c)
                {
                    getCard(comp);
                    if (getSum(comp) >= 16) c = false;
                    if (getSum(comp) > 21) c = p = false;
                }
                printCards(comp, "Computer");

                if (p && getSum(player) < 21)
                {
                    char choice = 'a';
                    Console.Write("\nPlayer do you want another card(y/n)?");
                    do
                    {
                        choice = Console.ReadKey().KeyChar;
                    }
                    while (choice != 'y' && choice != 'Y' && choice != 'n' && choice != 'N' );

                    if (choice == 'y' || choice == 'Y')
                        getCard(player);
                    if (choice == 'n' || choice == 'N')
                        p = false;
                    printCards(player, "Player");
                }
                if (getSum(player) > 21)
                {
                    Console.WriteLine("Computer WINS!!!");
                    c = p = false;
                }
                if (getSum(comp) > 21)
                {
                    Console.WriteLine("Player WINS!!!");
                    c = p = false;
                }
                if(!p && !c)
                {
                    printCards(comp, "Computer");
                    printCards(player, "Player");
                    if ((getSum(comp) <= 21) && getSum(comp) > getSum(player)) Console.WriteLine("Computer WINS!!!");
                    if((getSum(player) <= 21) && getSum(player) > getSum(comp)) Console.WriteLine("Player WINS!!!");
                    if((getSum(player) <= 21) && getSum(player) == getSum(comp)) Console.WriteLine("Its a Tie!!!");

                }
            }
       
        }
    }
}
