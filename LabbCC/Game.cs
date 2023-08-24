namespace LabbCC;

public class Game
{
    private IUI _ui;
    public Game(IUI ui)
    {
        _ui = ui;
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
        
        int bulls = CheckBull(goal, guess);
        int cows = CheckCow(goal, guess);        
                
        string result = new string('B', bulls) + "," + new string('C', cows);
                
        return result;

    }
    public int CheckBull(string goal, string guess)
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
    public int CheckCow(string goal, string guess)
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

    public void HighscoreBoard()
    {        
        StreamReader streamReader = new StreamReader("result.txt");     //Fråga Benjamin om FileHandler?
        List<Player> scoreBoard = new List<Player>();
        string line = streamReader.ReadLine();
        while (line != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            //string name = nameAndScore[0];
            //int guesses = Convert.ToInt32(nameAndScore[1]);
            Player playerData = new Player(nameAndScore[0], Convert.ToInt32(nameAndScore[1]));
            int position = scoreBoard.IndexOf(playerData);
            if (position < 0)
            {
                scoreBoard.Add(playerData);
            }
            else
            {
                scoreBoard[position].Update(Convert.ToInt32(nameAndScore[1]));
            }

        }
        streamReader.Close();

        scoreBoard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        _ui.Output("Player   games average");
        foreach (Player player in scoreBoard)
        {
            _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.GamesPlayed, player.Average()));
        }
    }

}
