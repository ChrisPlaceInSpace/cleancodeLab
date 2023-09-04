namespace LabbCC;

internal class MasterMindGameLogic : IGameLogic
{
    private readonly IUI ui;
    public MasterMindGameLogic(IUI ui)
    {
        this.ui = ui;
    }
    public string GoalGenerator()
    {
        try
        {
            Random randomGenerator = new Random();
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(1, 6);
                switch (random)
                {
                    case 1:
                        goal += "R";
                        break;
                    case 2:
                        goal += "G";
                        break;
                    case 3:
                        goal += "B";
                        break;
                    case 4:
                        goal += "Y";
                        break;
                    case 5:
                        goal += "W";
                        break;
                    case 6:
                        goal += "P";
                        break;
                }
            }
            return goal;
        }
        catch (Exception ex) { ui.Output("Could not generate target numbers. \n" + ex); return ""; }
    }

    public int PlayLogic(int numberOfGuesses)
    {
        try
        {
            string guess;
            string goal = GoalGenerator();
            //comment out or remove next line to play real games!
            ui.Output("For practice, colors are: " + goal + "\n");
            do
            {
                guess = ui.Input().ToUpper();
                numberOfGuesses++;
                ui.Output(GameStringBuilder(goal, guess)+"\n");
            } while (!GameStringBuilder(goal, guess).StartsWith("XXXX"));
            return numberOfGuesses;
        }
        catch (Exception ex) { ui.Output("Could not run PlayLogics. \n" + ex); return 0; }
    }

    public string GameStringBuilder(string goal, string guess)
    {
        try
        {
            int hits = CountHit(goal, guess);
            int misses = CountMiss(goal, guess);

            string hitsAndMisses = new string('X', hits) + new string('O', misses);

            return hitsAndMisses;
        }
        catch (Exception ex) { ui.Output("Could not compile result from hits and misses. \n" + ex); return ""; }

    }

    public int CountHit(string goal, string guess)
    {
        try
        {
            int hit = 0;
            guess += "    ";
            for (int i = 0; i < 4; i++)
            {
                if (goal[i] == guess[i])
                {
                    hit++;
                }
            }
            return hit;
        }
        catch (Exception ex) { ui.Output("Could not count hits. \n" + ex); return 0; }
    }

    public int CountMiss(string goal, string guess)
    {
        try
        {
            int miss = 0;
            guess += "    ";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j] && i != j)
                    {
                        miss++;
                    }
                }
            }
            return miss;
        }
        catch (Exception ex) { ui.Output("Could not count misses. \n" + ex); return 0; }
    }
}