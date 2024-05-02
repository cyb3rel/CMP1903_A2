using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace CMP1903_A2
{
    // SO inherits from Game superclass
    internal class SevensOut : Game
    {
        // assigns NumberOfDice as 2
        public override int NumberOfDice => 2;

        public override void Play(bool isTwoPlayer)
        {
            // instantiate 2 dice objects
            // create an array to hold dice objects
            Die[] dice = new Die[NumberOfDice];
            // iterate over each element of the dice array
            for (int i = 0; i < NumberOfDice; i++)
            {
                // instantiate a new Die object and assign it to current element
                dice[i] = new Die();
            }

            // total of the dice for P1
            int dieTotal1 = 0;
            // total of the dice for P2/Comp
            int dieTotal2 = 0;
            // temporary total (to check for a total of 7)
            int temp = 0;

            string rules = "Two dice are rolled each turn, with the total being noted. \nA double number adds double the total to your score. \nA 7 ends the game. \n";

            // runs game with two players
            // prints rules out
            Console.WriteLine(rules);

            do
            {
                // PLAYER ONE
                Console.WriteLine("Player 1 press any key to roll: ");
                // checks for a key press before continuing to roll dice
                Console.ReadKey();

                // roll both dice
                for (int i = 0; i < NumberOfDice; i++)
                {
                    dice[i].Roll();
                }

                // print dice rolls, total of dice & current score
                Console.WriteLine("\n Player 1 rolled: ");
                foreach (var die in dice)
                {
                    Console.WriteLine($"{die.diceValue} ");
                }

                // calculate total of rolls
                temp = dice.Sum(die => die.diceValue);
                
                // check for doubles
                if (dice[0].diceValue == dice[1].diceValue)
                {
                    // double temp
                    temp =+ temp;
                    Console.WriteLine($"Player rolled doubles!! Dice total doubles to {temp}");
                }
                else
                {
                    Console.WriteLine($"Dice total: {temp}");
                }                
                // add total to player score
                dieTotal1 += temp;
                Console.WriteLine($"Current score: {dieTotal1} \n");

                // check to end game
                if (temp == 7)
                {
                    Console.WriteLine("Player 1 rolled a total of 7. Game Over");
                    break;
                }

                if (isTwoPlayer)
                {
                    // PLAYER TWO
                    Console.WriteLine("Player 2 press any key to roll: ");
                    // checks for a key press before continuing to roll dice
                    Console.ReadKey();

                    // roll both dice
                    for (int i = 0; i < NumberOfDice; i++)
                    {
                        dice[i].Roll();
                    }

                    // print dice rolls, total of dice & current score
                    Console.WriteLine("\n Player 2 rolled: ");
                    foreach (var die in dice)
                    {
                        Console.WriteLine($"{die.diceValue} ");
                    }

                    // calculate total of rolls
                    temp = dice.Sum(die => die.diceValue);

                    // check for doubles
                    if (dice[0].diceValue == dice[1].diceValue)
                    {
                        // double temp
                        temp = +temp;
                        Console.WriteLine($"Player rolled doubles!! Dice total doubles to {temp}");
                    }
                    else
                    {
                        Console.WriteLine($"Dice total: {temp}");
                    }
                    // add total to player score
                    dieTotal2 += temp;
                    Console.WriteLine($"Current score: {dieTotal2} \n");

                    // check to end game
                    if (temp == 7)
                    {
                        Console.WriteLine("Player 2 rolled a total of 7. Game Over");
                        break;
                    }
                }
                else
                {
                    // COMPUTER
                    Console.WriteLine("Computer is rolling. . .");
                    
                    // roll both dice
                    for (int i = 0; i < NumberOfDice; i++)
                    {
                        dice[i].Roll();
                    }

                    // print dice rolls, total of dice & current score
                    Console.WriteLine("\n Computer rolled: ");
                    foreach (var die in dice)
                    {
                        Console.WriteLine($"{die.diceValue} ");
                    }

                    // calculate total of rolls
                    // LINQ used
                    temp = dice.Sum(die => die.diceValue);

                    // check for doubles
                    if (dice[0].diceValue == dice[1].diceValue)
                    {
                        // double temp
                        temp = +temp;
                        Console.WriteLine($"Computer rolled doubles!! Dice total doubles to {temp}");
                    }
                    else
                    {
                        Console.WriteLine($"Dice total: {temp}");
                    }                    // add total to computer score
                    dieTotal2 += temp;
                    Console.WriteLine($"Current score: {dieTotal2} \n");

                    // check to end game
                    if (temp == 7)
                    {
                        Console.WriteLine("Computer rolled a total of 7. Game Over");
                        break;
                    }
                }
            }
            while (temp != 7);

            int highestDie = 0;

            if (dieTotal1 >= dieTotal2)
            {
                highestDie = dieTotal1;
            }
            else
            {
                highestDie = dieTotal2;
            }

            Console.WriteLine($"Highest total: {highestDie}");

            // increase number of plays by 1
            Statistics.IncrementPlays<SevensOut>();

            int highScore = CalculateHighScore<SevensOut>(highestDie);

            // update stats after game is played
            UpdateStatistics<SevensOut>(highScore);

            Console.WriteLine("Press any key to return to menu ");
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }
    }
}