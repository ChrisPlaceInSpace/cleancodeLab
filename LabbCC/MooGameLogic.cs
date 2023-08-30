using LabbCC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbCC
{
    public class MooGameLogic
    {
        IUI ui = new ConsoleIO();

        public void Logic(int numberOfGuesses, string result)
        {
            string goal = TargetDigits();
            //comment out or remove next line to play real games!
            ui.Output("For practice, number is: " + goal + "\n");
            do
            {
                string guess = ui.Input();
                numberOfGuesses++;
                result = CheckBullAndCow(goal, guess);
                ui.Output(result + "\n");
            } while (!result.StartsWith("BBBB,"));
        }
        public string TargetDigits()
        {
            Random randomGenerator = new Random();
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;

                goal += randomDigit;
            }
            return goal;
        }
        public string CheckBullAndCow(string goal, string guess)
        {

            int bulls = CountBull(goal, guess);
            int cows = CountCow(goal, guess);

            string result = new string('B', bulls) + "," + new string('C', cows);

            return result;

        }
        public int CountBull(string goal, string guess)
        {
            int bull = 0;
            guess += "    ";
            for (int i = 0; i < 4; i++)
            {
                if (goal[i] == guess[i])
                {
                    bull++;
                }
            }
            return bull;
        }
        public int CountCow(string goal, string guess)
        {
            int cow = 0;
            guess += "    ";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j] && i != j)
                    {
                        cow++;
                    }

                }
            }
            return cow;
        }
    }
}
