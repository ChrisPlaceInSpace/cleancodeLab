using LabbCC;

namespace LabbCCTests;

public class MockMooGameLogic : IGameLogic
{
    IUI ui = new ConsoleIO();

    public int PlayLogic(int numberOfGuesses)
    {
        string guess;
        string goal = "0000";
        //comment out or remove next line to play real games!
        ui.Output("For practice, number is: " + goal + "\n");
        do
        {
            guess = "0000";
            numberOfGuesses++;
            ui.Output(GameStringBuilder(goal, guess));
        } while (!GameStringBuilder(goal, guess).StartsWith("BBBB"));
        return numberOfGuesses;
    }
    public string GoalGenerator()
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
    public string GameStringBuilder(string goal, string guess)
    {

        int bulls = CountHit(goal, guess);
        int cows = CountMiss(goal, guess);

        string bullCow = new string('B', bulls) + new string('C', cows);

        return bullCow;

    }
    public int CountHit(string goal, string guess)
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
    public int CountMiss(string goal, string guess)
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
