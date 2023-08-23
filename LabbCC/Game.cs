namespace LabbCC;

public class Game
{
    private IUI _ui;
    public Game(IUI ui)
    {
        _ui = ui;
    }
    
    public string TargetDigits()        //Changed name
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
        int cows = 0, bulls = 0;
        guess += "    ";     // if player entered less than 4 chars
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }
        }
        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
    }


    public void HighscoreBoard()        
    {
        StreamReader input = new StreamReader("result.txt");
        List<Player> scoreBoard = new List<Player>();   //Ändra Result till playerScoreboard/gameResult
        string line;
        while ((line = input.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            Player pd = new Player(name, guesses);      //pd ändras till playerInfo
            int pos = scoreBoard.IndexOf(pd);       //pos = position? Möjlig ändring
            if (pos < 0)
            {
                scoreBoard.Add(pd);
            }
            else
            {
                scoreBoard[pos].Update(guesses);
            }
            


        }
        scoreBoard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        _ui.Output("Player   games average");
        foreach (Player p in scoreBoard)
        {
            _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.GamesPlayed, p.Average()));
        }
        input.Close();
    }

}
