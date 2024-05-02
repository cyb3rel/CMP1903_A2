using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            // load stats from file
            Statistics.LoadStatsFromFile();

            // MENU
            Console.WriteLine("Welcome! \n 1. Sevens Out \n 2. Three or More \n 3. Stats \n 4. Test Program \n 5. Exit \n");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine(" 1. Single Player \n 2. 2 Players \n");
                    string players = Console.ReadLine();

                    // create an instance of SevensOut
                    var sevensOut = new SevensOut();

                    switch (players)
                    {
                        // calls PlaySevensOut from SevensOut as a single player game
                        case "1":
                            sevensOut.Play(false);
                            break;
                        // calls PlaySevensOut from SevensOut as two player
                        case "2":
                            sevensOut.Play(true);
                            break;
                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine(" 1. Single Player \n 2. 2 Players \n");
                    string players2 = Console.ReadLine();

                    // create an instance of Three or More
                    var threeOrMore = new ThreeOrMore();

                    switch (players2)
                    {
                        // calls PlayThreeOrMore from ThreeOrMore as a single player game
                        case "1":
                            threeOrMore.Play(false);
                            break;
                        // calls PlayThreeOrMore from ThreeOrMore as two player
                        case "2":
                            threeOrMore.Play(true);
                            break;
                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                    break;
                case "3":
                    // calls Stats method from Statistics class
                    Statistics.PrintStats();
                    break;
                case "4":
                    Testing.testGame();
                    break;
                case "5":
                    // exits the console application
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}
