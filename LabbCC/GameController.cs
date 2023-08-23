namespace LabbCC;

public class GameController
{
    private IUI _ui;
    private Game _game;
    public GameController(Game game, IUI ui)
    {
           _game = game;
           _ui = ui;
    }
    public void RunGame()
    {
        bool gameOn = true;         
        _ui.Output("Enter your user name:\n");
        string userName = _ui.Input();


        while(gameOn)
        {
            PlayGame();
            _ui.Output("Continue? \nYes(y) / No(n)");
            string answer = _ui.Input();
            gameOn = (answer != "" && answer.ToLower() != "n");
            
        }

        void PlayGame()
        {
            string goal = _game.TargetDigits();
            _ui.Output("New game:\n");
            //comment out or remove next line to play real games!
            _ui.Output("For practice, number is: " + goal + "\n");
            int numberOfGuesses = 0;
            string result;
            do
            {
                numberOfGuesses++;
                string guess = _ui.Input();                
                result = _game.CheckBullAndCow(goal, guess);
               _ui.Output(result + "\n");
            } while (result != "BBBB,");

            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(userName + ", Score: " + numberOfGuesses);
            output.Close();

            _game.HighscoreBoard();

           _ui.Output("Correct, it took " + numberOfGuesses + " guesses");
            
        }

                      
                   



        
    }
    
}
