using LabbCC;

namespace LabbCCTests;

public class MockMooGameLogic : GameLogic
{
    IUI ui;
    public MockMooGameLogic(IUI UI) : base(UI)
    {
        this.ui = UI;
    }
    public override void PrintGameIntructions()
    {
        throw new NotImplementedException();
    }
    public override string GoalGenerator()
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
    public override int PlayLogic()
    {
        string guess;
        string goal = "0000";
        int numberOfGuesses = 0;
        //comment out or remove next line to play real games!
        ui.Output("For practice, number is: " + goal + "\n");
        do
        {
            guess = "0000";
            numberOfGuesses++;
            ui.Output(ResultFromGuess(goal, guess));
        } while (!ResultFromGuess(goal, guess).StartsWith("BBBB"));
        return numberOfGuesses;
    }
    public override int CountHit(string goal, string guess)
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
    public override int CountMiss(string goal, string guess)
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
    public override string ResultFromGuess(string goal, string guess)
    {

        int bulls = CountHit(goal, guess);
        int cows = CountMiss(goal, guess);

        string bullCow = new string('B', bulls) + new string('C', cows);

        return bullCow;

    }
}
