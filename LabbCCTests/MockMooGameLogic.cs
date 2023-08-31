using LabbCC.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabbCCTests;

public class MockMooGameLogic : IGameLogic
{
    readonly IUI ui;
    public string GoalGenerator()
    {        
        return GoalGenerator();
    }

    public int Logic(int numberOfGuesses)
    {
        string result;
        string goal = GoalGenerator();
        //comment out or remove next line to play real games!
        ui.Output("For practice, number is: " + goal + "\n");
        do
        {
            string guess = ui.Input();
            numberOfGuesses++;
            result = CheckBullAndCow(goal, guess);
            ui.Output(result + "\n");
        } while (!result.StartsWith("BBBB,"));
        return numberOfGuesses;
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
