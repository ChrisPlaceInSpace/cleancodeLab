namespace LabbCC;

public class Game
{
    public Game()
    {
            
    }
    public void RunGame()
    {
        bool activeGame = true;         //Changed name
        Console.WriteLine("Enter your user name:\n");
        string name = Console.ReadLine();

        while (activeGame)
        {
            string goal = TargetDigits();


            Console.WriteLine("New game:\n");
            //comment out or remove next line to play real games!
            //Console.WriteLine("For practice, number is: " + goal + "\n");
            string guess = Console.ReadLine();

            int numberOfGuesses = 1;
            string bbcc = CheckBullAndCow(goal, guess);
            Console.WriteLine(bbcc + "\n");
            while (bbcc != "BBBB,")
            {
                numberOfGuesses++;
                guess = Console.ReadLine();
                Console.WriteLine(guess + "\n");
                bbcc = CheckBullAndCow(goal, guess);
                Console.WriteLine(bbcc + "\n");
            }
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
            HighscoreBoard();
            Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
            string answer = Console.ReadLine();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")        //Förenkla till =="n"
            {
                activeGame = false;
            }
        }
    }
        public static string TargetDigits()        //Changed name
    {
        Random randomGenerator = new Random();
        string goal = "";
        for (int i = 0; i < 4; i++)
        {
            int random = randomGenerator.Next(10);
            string randomDigit = "" + random;
            //while (goal.Contains(randomDigit))		//Removed While loop
            //{
            //	random = randomGenerator.Next(10);
            //	randomDigit = "" + random;
            //}
            goal += randomDigit;
        }
        return goal;
    }

    public static string CheckBullAndCow(string goal, string guess)
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


    public static void HighscoreBoard()        //Switched to PascalCasing and better name excluding "List".
    {
        StreamReader input = new StreamReader("result.txt");
        List<Player> gameResult = new List<Player>();   //Ändra Result till playerScoreboard/gameResult
        string line;
        while ((line = input.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            Player pd = new Player(name, guesses);      //pd ändras till playerInfo
            int pos = gameResult.IndexOf(pd);       //pos = position? Möjlig ändring
            if (pos < 0)
            {
                gameResult.Add(pd);
            }
            else
            {
                gameResult[pos].Update(guesses);
            }


        }
        gameResult.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        Console.WriteLine("Player   games average");
        foreach (Player p in gameResult)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.GamesPlayed, p.Average()));
        }
        input.Close();
    }
}
