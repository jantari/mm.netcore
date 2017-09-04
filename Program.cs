using System;
using System.Linq;

namespace mmdotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] pinXmatched = {false,false,false,false};
            bool[] pinOmatched = {false,false,false,false};
            bool won = false;

            Console.WriteLine("Welcome to MasterMind.NET!");

            char[] mmPins = {'0','1','2','3'}; // MasterMinds Pins
            char[] ugPins = new char[4]; // user-guessed Pins
            string userInput = String.Empty;
            for (byte round = 1; won == false && round < 11 ; round++) {

                Console.WriteLine("=== Round {0} ===", round);

                while (userInput.Length < 4) {
                    userInput = Console.ReadLine();
                }
                ugPins = userInput.ToCharArray();
                Console.WriteLine("Your guess: {0}{1}{2}{3}",ugPins[0],ugPins[1],ugPins[2],ugPins[3]);

                if (Enumerable.SequenceEqual(ugPins,mmPins)) {
                    won = true;
                    break;
                } else {
                    // If users guess does not match MMs pins exactly ...
                    // ... check for exact matches (X-matches) on each position ...
                    for (byte checkingPin = 0; checkingPin < 4; checkingPin++) {
                        if (mmPins[checkingPin] == ugPins[checkingPin]) {
                            Console.Write("X");
                            pinXmatched[checkingPin] = true;
                        }
                    }
                    // ... and then O-matches!
                    for (byte checkingPin = 0; checkingPin < 4; checkingPin++) {
                        if (pinXmatched[checkingPin] == false) {
                            for (byte userPin = 0; userPin < 4; userPin++) {
                                if (pinXmatched[userPin] == false && pinOmatched[userPin] == false) {
                                    if (mmPins[checkingPin] == ugPins[userPin]) {
                                        pinOmatched[userPin] = true;
                                        Console.Write("O");
                                    }
                                }
                            }
                        }
                    }
                    Array.Clear(pinXmatched, 0, 4);
                    Array.Clear(pinOmatched, 0, 4);
                    userInput = String.Empty;
                    Console.Write("\n");
                }
            }

            if (won == true) {
                Console.WriteLine("GEWONNEN!");
            } else {
                Console.WriteLine("Verloren ...");
		Console.WriteLine("Die Pins waeren {0} gewesen",new string(mmPins));
            }

        }
    }
}
