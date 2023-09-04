
namespace LabbCC;

public class MooGameLogic : IGameLogic
{
    private readonly IUI ui;
    public MooGameLogic(IUI ui)
    {
        this.ui = ui;
    }

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
                ui.Output(GameStringBuilder(goal, guess));
            } while (!GameStringBuilder(goal, guess).StartsWith("BBBB"));
            return numberOfGuesses;
        }
        catch (Exception ex) { ui.Output("Could not run PlayLogics. \n" + ex); return 0; }
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
        catch (Exception ex) { ui.Output("Could not generate target numbers. \n" + ex); return ""; }
    }
    public string GameStringBuilder(string goal, string guess)
    {
        try
        {
            int hits = CountHit(goal, guess);
            int misses = CountMiss(goal, guess);

            string hitsAndMisses = new string('B', hits) + new string('C', misses);

            return hitsAndMisses;
        }
        catch (Exception ex) { ui.Output("Could not compile result from cows and bulls. \n" + ex); return ""; }

    }
    public int CountHit(string goal, string guess)
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
        catch (Exception ex) { ui.Output("Could not count bulls. \n" + ex); return 0; }
    }
    public int CountMiss(string goal, string guess)
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
        catch (Exception ex) { ui.Output("Could not count cows. \n" + ex); return 0; }
    }

}
