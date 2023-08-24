namespace LabbCC;

public class Game
{
    private IUI _ui;
    public Game(IUI ui)
    {
        _ui = ui;
    }
    List<Player> scoreBoard = new List<Player>();

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

    public void WriteToFile(string userName, int numberOfGuesses)
    {
        StreamWriter output = new StreamWriter("result.txt", append: true);
        {
            output.WriteLine($"{userName}#&#{numberOfGuesses}");
            output.Close();
        }
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
            Player playerData = new Player(name, score);
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
        _ui.Output("Player   games average");
        foreach (Player player in scoreBoard)
        {
            _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.GamesPlayed, player.Average()));
        }
    }

}
