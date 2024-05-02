using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CMP1903_A2
{
    internal class Statistics
    {
        private static string filePath = "statistics.json";

        // list to store stats for each game
        private static List<GameStats> gameStatsList = new List<GameStats>();

        // load stats when class is first used
        static Statistics()
        {
            LoadStatsFromFile();
        }

        // retrieve stats
        public static GameStats GetStats<T>() where T : Game
        {
            // find corresponding GameStats object
            return gameStatsList.FirstOrDefault(stats => stats.GameType == typeof(T));
        }

        // update or create stats
        public static void UpdateStats<T>(int highScore) where T : Game
        {
            // find corresponding GameStats object
            var stats = gameStatsList.FirstOrDefault(s => s.GameType == typeof(T));

            if (stats == null)
            {
                // if no stats exist, create new stats
                stats = new GameStats
                {
                    GameType = typeof(T),
                    HighScore = highScore,
                    NumberOfPlays = 1
                };
                // add the new stats to the list
                gameStatsList.Add(stats);
            }
            else
            {
                // update existing stats
                stats.HighScore = Math.Max(stats.HighScore, highScore);
            }
            SaveStatsToFile();
        }

        // method to save stats to JSON file
        private static void SaveStatsToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(gameStatsList, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                // error message
                Console.WriteLine($"Error saving statistics to file: {ex.Message}");
            }
        }

        // method to load stats from JSON file
        public static void LoadStatsFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                gameStatsList = JsonConvert.DeserializeObject<List<GameStats>>(json);
            }
        }

        // method to print all stats
        public static void PrintStats()
        {
            foreach (var stats in gameStatsList)
            {
                Console.WriteLine($"{stats.GameType.Name}");
                Console.WriteLine($"Times played: {stats.NumberOfPlays}");
                Console.WriteLine($"High score: {stats.HighScore}");
            }

            // return to menu
            Console.WriteLine("Press any key to return to menu ");
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }

        public static int GetPlays<T>() where T : Game
        {
            var stats = gameStatsList.FirstOrDefault(s => s.GameType == typeof(T));
            return stats?.NumberOfPlays ?? 0;
        }

        // method to increase number of plays
        public static void IncrementPlays<T>() where T : Game
        {
            var stats = gameStatsList.FirstOrDefault(s => s.GameType == typeof(T));

            if(stats == null)
            {
                // if no stats exist, create new stats
                stats = new GameStats
                {
                    GameType = typeof(T),
                    HighScore = 0,
                    WinLossRatio = 0,
                    NumberOfPlays = 1
                };
                // add stats to the list
                gameStatsList.Add(stats);
            }
            else
            {
                // increment NumberOfPlays
                stats.NumberOfPlays++;
            }
            SaveStatsToFile();
        }
    }

    internal class GameStats
    {
        public Type GameType { get; set; }
        public int NumberOfPlays { get; set; }
        public int HighScore {  get; set; }
        public double WinLossRatio {  get; set; }
    }
}
