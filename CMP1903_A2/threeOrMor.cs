using System;

namespace CMP1903_A2
{
    // TOM class inherits from Game superclass
    internal class ThreeOrMore : Game
    {
        // assigns NumberOfDice as 5
        public override int NumberOfDice => 5;
        public override void Play(bool isTwoPlayer)
        {
            // instantiate 5 dice objects
            // create an array to hold dice objects
            Die[] dice = new Die[NumberOfDice];
            // iterate over each element of the dice array
            for (int i = 0; i < NumberOfDice; i++)
            {
                // instantiate a new Die object and assign it to current element
                dice[i] = new Die();
            }

            // Player 1 points
            int dieTotal1 = 0;
            // Player 2/Computer points
            int dieTotal2 = 0;

            do
            {
                Console.WriteLine("Player 1 press any key to roll: ");
                // checks for a key press before continuing to roll dice
                Console.ReadKey();

                // array to count each dice value
                // each index represents the dice value
                int[] counts = new int[6];

                // roll 5 dice
                RollDice(dice, counts);

                // print dice rolls, total of dice & current score
                Console.WriteLine("\n Player 1 rolled: ");
                foreach (var die in dice)
                {
                    Console.WriteLine($"{die.diceValue} ");
                }

                int points = CheckCombinations(counts);

                if (points == 1)
                {
                    points = 0;
                    Console.WriteLine("Rolled 2-of-a-kind! Do you want to reroll 3 or 5 of your dice? (3/5) ");
                    string reroll = Console.ReadLine();

                    // if 2-of-a-kind -> rethrow all, or just the remaining dice
                    if (reroll == "5")
                    {
                        // rethrow all
                        // roll 5 dice
                        RollDice(dice, counts);

                        // print dice rolls, total of dice & current score
                        Console.WriteLine("\n Player 1 rolled: ");
                        foreach (var die in dice)
                        {
                            Console.WriteLine($"{die.diceValue} ");
                        }
                        points = CheckCombinations(counts);
                        if (points >= 3)
                        {
                            Console.WriteLine($"Player scored {points} points!");
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                    else if (reroll == "3")
                    {
                        // find the dice that aren't 2-of-a-kind
                        var rerollIndex = new List<int>();
                        for (int i = 0; i < counts.Length; i++)
                        {
                            if (counts[i] != 2)
                            {
                                rerollIndex.Add(i);
                            }
                        }

                        // reroll the dice that aren't 2-of-a-kind
                        var rerollDice = dice.Where((die, index) => rerollIndex.Contains(index)).ToArray();
                        RollDice(rerollDice, counts);

                        // print dice rolls, total of dice & current score
                        Console.WriteLine("\n Player 1 rolled: ");
                        foreach (var die in dice)
                        {
                            Console.WriteLine($"{die.diceValue} ");
                        }
                        points = CheckCombinations(counts);
                        if (points >= 3)
                        {
                            Console.WriteLine($"Player scored {points} points!");
                        }
                        else
                        {
                            points = 0;
                        }
                    }
                    else
                    {
                        // error handling
                        Console.WriteLine("Invalid input! No reroll. ");
                    }
                }
                else if (points == 0)
                {
                    Console.WriteLine("No combinations");
                }
                else
                {
                    Console.WriteLine($"Player scored {points} points!");
                }

                dieTotal1 += points;
                Console.WriteLine($"Current total: {dieTotal1}");

                if (isTwoPlayer)
                {
                    // runs game with two players
                    // PLAYER TWO
                    Console.WriteLine("Player 2 press any key to roll: ");
                    // checks for a key press before continuing to roll dice
                    Console.ReadKey();

                    // array to count each dice value
                    // each index represents the dice value
                    counts = new int[6];

                    // roll 5 dice
                    RollDice(dice, counts);

                    // print dice rolls, total of dice & current score
                    Console.WriteLine("\n Player 2 rolled: ");
                    foreach (var die in dice)
                    {
                        Console.WriteLine($"{die.diceValue} ");
                    }

                    points = CheckCombinations(counts);

                    if (points == 1)
                    {
                        points = 0;
                        Console.WriteLine("Rolled 2-of-a-kind! Do you want to reroll 3 or 5 of your dice? (3/5) ");
                        string reroll = Console.ReadLine();

                        // if 2-of-a-kind -> rethrow all, or just the remaining dice
                        if (reroll == "5")
                        {
                            // rethrow all
                            // roll 5 dice
                            RollDice(dice, counts);

                            // print dice rolls, total of dice & current score
                            Console.WriteLine("\n Player 1 rolled: ");
                            foreach (var die in dice)
                            {
                                Console.WriteLine($"{die.diceValue} ");
                            }

                            points = CheckCombinations(counts);
                            if (points >= 3)
                            {
                                Console.WriteLine($"Player scored {points} points!");
                            }
                            else
                            {
                                points = 0;
                            }
                        }
                        else if (reroll == "3")
                        {
                            // find the dice that aren't 2-of-a-kind
                            var rerollIndex = new List<int>();
                            for (int i = 0; i < counts.Length; i++)
                            {
                                if (counts[i] != 2)
                                {
                                    rerollIndex.Add(i);
                                }
                            }

                            // reroll the dice that aren't 2-of-a-kind
                            var rerollDice = dice.Where((die, index) => rerollIndex.Contains(index)).ToArray();
                            RollDice(rerollDice, counts);

                            // print dice rolls, total of dice & current score
                            Console.WriteLine("\n Player 1 rolled: ");
                            foreach (var die in dice)
                            {
                                Console.WriteLine($"{die.diceValue} ");
                            }

                            points = CheckCombinations(counts);
                            if (points >= 3)
                            {
                                Console.WriteLine($"Player scored {points} points!");
                            }
                            else
                            {
                                points = 0;
                            }
                        }
                        else
                        {
                            // error handling
                            Console.WriteLine("Invalid input! No reroll. ");
                        }
                    }
                    else if (points == 0)
                    {
                        Console.WriteLine("No combinations");
                    }
                    else
                    {
                        Console.WriteLine($"Player scored {points} points!");
                    }

                    dieTotal2 += points;
                    Console.WriteLine($"Current total: {dieTotal2}");
                }
                else
                {
                    // runs game as a single player
                    // COMPUTER
                    Console.WriteLine("Computer is rolling. . .");

                    RollDice(dice, counts);

                    // print dice rolls, total of dice & current score
                    Console.WriteLine("\n Computer rolled: ");
                    foreach (var die in dice)
                    {
                        Console.WriteLine($"{die.diceValue} ");
                    }
                }
            }

            while (dieTotal1 < 20 && dieTotal2 < 20);

            int highestDie = 0;

            if (dieTotal1 >= dieTotal2)
            {
                highestDie = dieTotal1;
            }
            else
            {
                highestDie = dieTotal2;
            }

            // increase number of plays by 1
            Statistics.IncrementPlays<ThreeOrMore>();

            int highScore = CalculateHighScore<SevensOut>(highestDie);

            // update stats with the new play count
            UpdateStatistics<ThreeOrMore>(highScore);

            Console.WriteLine("Press any key to return to menu ");
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }

        // method to roll and update counts
        private void RollDice(Die[] dice, int[] counts)
        {
            // roll all dice
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i].Roll();
            }

            // clear counts array
            Array.Clear(counts, 0, counts.Length);

            // update counts
            foreach (var die in dice)
            {
                // increment count at each index
                // dice values start at 1 but array starts at 0
                // so we -1 from the dice value to get correct index
                counts[die.diceValue - 1]++;
            }
        }

        private static int CheckCombinations(int[] counts)
        {
            for (int i = 0; i < counts.Length; i++)
            {
                int count = counts[i];
                // dice value (index + 1)
                int value = i + 1;

                switch (count)
                {
                    case 2:
                        return 1; // special case
                    case 3:
                        // 3-of-a-kind = 3 points
                        return 3;
                    case 4:
                        // 4-of-a-kind = 6 points
                        return 6;
                    case 5:
                        // 5-of-a-kind = 12 points
                        return 12;
                }
            }
            return 0;
        }
    }
}
