using LabbCC.Interfaces;

namespace LabbCC.MooGame
{
    public class MooGameLogic : IGameLogic
    {
        IUI ui = new ConsoleIO();

        public int PlayLogic(int numberOfGuesses)
        {
            try
            {
                string guess;
                string goal = GoalGenerator();
                //comment out or remove next line to play real games!
                ui.Output("For practice, number is: " + goal + "\n");
                do
                {
                    guess = ui.Input();
                    numberOfGuesses++;
                    ui.Output(BullAndCowStringBuilder(goal, guess));
                } while (!BullAndCowStringBuilder(goal, guess).StartsWith("BBBB"));
                return numberOfGuesses;
            }
            catch (Exception ex) { Console.WriteLine("Could not run PlayLogics. \n" + ex); return 0; }
        }
        public string GoalGenerator()
        {
            try
            {
                Random randomGenerator = new Random();
                string goal = "";
                for (int i = 0; i < 4; i++)
                {
                    int random = randomGenerator.Next(10);
                    goal += random;
                }
                return goal;
            }
            catch (Exception ex) { Console.WriteLine("Could not generate target numbers. \n" + ex); return ""; }
        }
        public string BullAndCowStringBuilder(string goal, string guess)
        {
            try
            {
                int bulls = CountBull(goal, guess);
                int cows = CountCow(goal, guess);

                string bullCow = new string('B', bulls) + new string('C', cows);

                return bullCow;
            }
            catch (Exception ex) { Console.WriteLine("Could not compile result from cows and bulls. \n" + ex); return ""; }

        }
        public int CountBull(string goal, string guess)
        {
            try
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
            catch (Exception ex) { Console.WriteLine("Could not count bulls. \n" + ex); return 0; }
        }
        public int CountCow(string goal, string guess)
        {
            try
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
            catch (Exception ex) { Console.WriteLine("Could not count cows. \n" + ex); return 0; }
        }

    }
}
