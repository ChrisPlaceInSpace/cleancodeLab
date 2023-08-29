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

    bool gameOn;
    public void RunGame()     //Göra denna mer generisk för fler spel?
    {
        gameOn = true;
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
            UpdateScoreBoard();
            PrintScoreBoard();
            Continue();
        }
    }

    public void Continue()
    {
        ui.Output("\nContinue? \nYes(y) / No(n)");
        string answer = ui.Input();
        try
        {
            if (answer != "y" || answer != "n")
            {
                ui.Output("Please print 'y' to continue or 'n' to quit");
            }
            else
            gameOn = answer != "n".ToLower();

        }
        catch
        {
            ui.Output("Invalid input");
            throw;
        }
        
        
        //return gameOn;
    }

    public void UpdateScoreBoard()
    {
        StreamReader streamReader = new StreamReader("result.txt");     //Fråga Benjamin om FileHandler?
        string line;
        while ((line = streamReader.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int score = Convert.ToInt32(nameAndScore[1]);
            PlayerDAO playerData = new PlayerDAO(name, score);
            int position = scoreBoard.IndexOf(playerData);
            //OM spelaren inte redan finns på poängtavlan så läggs det till en ny,
            //ANNARS uppdateras det gamla resultatet.
            if (position < 0)
            {
                scoreBoard.Add(playerData);
            }
            else
            {
                scoreBoard[position].UpdatePosition(score);
            }
        }
        streamReader.Close();

        //Sorterar poängtavlan baserat på resultatet av Average
        scoreBoard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

    }

    public void PrintScoreBoard()
    {
        ui.Output("Player   games average");
        foreach (PlayerDAO player in scoreBoard)
        {
            ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.GamesPlayed, player.Average()));
        }
    }

    public void WriteToFile(string userName, int numberOfGuesses)
    {
        try
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            {
                output.WriteLine($"{userName}#&#{numberOfGuesses}");
                output.Close();
            }
        }
        catch (Exception e)
        {
            ui.Output("Could not write to file\n" + e.ToString());
            throw;
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
