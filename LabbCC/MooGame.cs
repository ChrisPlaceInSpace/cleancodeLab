using System.Xml.Linq;

namespace LabbCC;

public class MooGame : IGame
{
    private IUI ui;
    public string GameName { get; set; }
    public MooGame(IUI _ui, string gameName)
    {
        ui = _ui;
        GameName = gameName;
    }
    List<PlayerDAO> scoreBoard = new List<PlayerDAO>();

    public void RunGame()     //Göra denna mer generisk för fler spel?
    {
        bool gameOn = true;
        ui.Clear();
        ui.Output("Enter your user name:\n");
        string userName = ui.Input();
        while (gameOn)
        {
            ui.Clear();
            string goal = TargetDigits();
            ui.Output("New game:\n");
            //comment out or remove next line to play real games!
            ui.Output("For practice, number is: " + goal + "\n");
            int numberOfGuesses = 0;
            string result;
            do
            {
                string guess = ui.Input();
                numberOfGuesses++;
                result = CheckBullAndCow(goal, guess);
                ui.Output(result + "\n");
            } while (!result.StartsWith("BBBB,"));
            WriteToFile(userName, numberOfGuesses);
            ui.Output($"Correct, it took {numberOfGuesses} guesses\n");
            UpdateScoreBoard(scoreBoard);
            PrintScoreBoard();
            gameOn = Continue();
        }
    }

    public bool Continue()
    {
        bool runLoop = true;
        while (runLoop)
        {
            ui.Output("\nContinue? \nYes(y) / No(n)");
            string answer = ui.Input();
            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if (answer == "n".ToLower())
            {
                return false;
            }
            else
                ui.Clear();
                ui.Output("Please enter 'y' to continue or 'n' to quit");

        }
        return false;
    }

    

    public void PrintScoreBoard()
    {
        //Sorterar poängtavlan baserat på resultatet av Average
        scoreBoard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

        ui.Output("Player   games average");
        foreach (PlayerDAO player in scoreBoard)
        {
            ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.GamesPlayed, player.Average()));
        }
       
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
