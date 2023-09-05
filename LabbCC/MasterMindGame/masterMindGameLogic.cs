namespace LabbCC;

internal class MasterMindGameLogic : GameLogic
{
    private readonly IUI _ui;
    public MasterMindGameLogic(IUI ui) : base(ui)
    {
        _ui = ui;
    }
    public override void PrintGameIntructions()
    {
        _ui.Clear();
        _ui.Output("Guess the Rocks:");
        _ui.Output("Q(Quartz), W(Wavellite), E(Emerald)\n" +
            "A(Amethyst), S(Sulfur), D(Diamond)\n");
        _ui.Output("New game:\n");
    }
    public override string GoalGenerator()
    {
        try
        {
            Random randomGenerator = new Random();
            string goal = "";
            Dictionary<int, char> map = new Dictionary<int, char>()
            {
                {1, 'Q' },
                {2, 'W' },
                {3, 'E' },
                {4, 'A' },
                {5, 'S' },
                {6, 'D' },
            };
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(1, 6);
                goal += map[random];
            }
            return goal;
        }
        catch (Exception ex) { _ui.Output("Could not generate target numbers. \n" + ex); return ""; }
    }
    public override int PlayLogic()
    {
        try
        {
            int numberOfGuesses = 0;
            string guess;
            string goal = GoalGenerator();
            //comment out or remove next line to play real games!
            _ui.Output("For practice, rocks are: " + goal + "\n");
            do
            {
                guess = _ui.Input().ToUpper();
                if (guess.Length != 4)
                {
                    _ui.Output("Enter 4 Letters, no more, no less!\n" +
                        "Q, W, E, A, S, D\n");
                }
                else
                {
                    numberOfGuesses++;
                    _ui.Output(ResultFromGuess(goal, guess) + "\n");
                }
            } while (!ResultFromGuess(goal, guess).StartsWith("XXXX"));
            _ui.Output($"Correct, it took {numberOfGuesses} guesses\n");
            return numberOfGuesses;
        }
        catch (Exception ex) { _ui.Output("Could not run PlayLogics. \n" + ex); return 0; }
    }
    public override int CountHit(string goal, string guess)
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
        catch (Exception ex) { _ui.Output("Could not count hits. \n" + ex); return 0; }
    }
    public override int CountMiss(string goal, string guess)
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
        catch (Exception ex) { _ui.Output("Could not count misses. \n" + ex); return 0; }
    }
    public override string ResultFromGuess(string goal, string guess) 
    {
        try
        {
            int hits = CountHit(goal, guess);
            int misses = CountMiss(goal, guess);

            string hitsAndMisses = new string('X', hits) + new string('O', misses);

            return hitsAndMisses;
        }
        catch (Exception ex) { _ui.Output("Could not compile result from hits and misses. \n" + ex); return ""; }

    }
}