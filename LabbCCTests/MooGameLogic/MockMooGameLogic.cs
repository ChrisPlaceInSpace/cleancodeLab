using LabbCC;
using LabbCC.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LabbCCTests.MooGame;

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
            ui.Output(BullAndCowStringBuilder(goal, guess));
        } while (!BullAndCowStringBuilder(goal, guess).StartsWith("BBBB"));
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
    public string BullAndCowStringBuilder(string goal, string guess)
    {

        int bulls = CountBull(goal, guess);
        int cows = CountCow(goal, guess);

        string bullCow = new string('B', bulls) + new string('C', cows);

        return bullCow;

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
