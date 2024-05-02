using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace CMP1903_A2
{
    internal class Testing
    {
        public static void testGame()
        {
            Console.WriteLine("Running tests. . . \n");

            // test die
            TestDie();
        }

        private static void TestDie()
        {
            // test dice works
            Die dice = new Die();
            int testDie = dice.Roll(); //creates a die object to be tested
            Debug.Assert(testDie >= 1 && testDie <= 6, "die is incorrect");
        }

        private static void TestSevensOut()
        {
            Console.WriteLine("Sevens Out test: ");

            SevensOut sevensOutTest = new SevensOut();
            sevensOutTest.Play(false);

            Console.WriteLine("Test successful");
        }

        private static void TestThreeOrMore()
        {
            Console.WriteLine("Three or More test: ");

            ThreeOrMore threeOrMoreTest = new ThreeOrMore();
            threeOrMoreTest.Play(false);

            Console.WriteLine("Test successful");
        }
    }
}
