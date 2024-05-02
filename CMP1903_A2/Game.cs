using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2
{
    internal interface IGame
    {
        // property used to retrieve number of dice needed to play
        int NumberOfDice {  get; }

        // method for playing
        void Play(bool isTwoPlayer);
    }

    // Game class uses IGame interface
    internal abstract class Game : IGame
    {
        public abstract int NumberOfDice { get; }
        public abstract void Play(bool isTwoPlayer);
        
        protected void UpdateStatistics<T>(int highScore) where T : Game 
        {
            int plays = Statistics.GetPlays<T>();
            Statistics.UpdateStats<T>(highScore);
        }

        protected static int CalculateHighScore<T>(int highestDice) where T : Game
        {
            int plays = Statistics.GetPlays<T>();

            int highScore = highestDice;

            return highScore;
        }
    }
}

