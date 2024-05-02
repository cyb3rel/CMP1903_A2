using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2
{
    internal class Die
    {
        // encapsulation
        private static Random random = new Random();
        public int diceValue { get; set; } //stores values after rolling dice
        public void Roll() //roll dice
        {
            diceValue = random.Next(1, 7); //generates a random number between 1 and 6
        }
    }
}
