namespace LabbCC;

public class GameController
{
    private IUI ui;
    private Game game;
    public GameController(Game _game, IUI iui)
    {
        game = _game;
        ui = iui;
    }
    public void RunGame()
    {
        bool gameOn = true;
        ui.Output("Enter your user name:\n");
        string userName = ui.Input();


        while (gameOn)
        {
            PlayGame();
            ui.Output("Continue? \nYes(y) / No(n)");
            string answer = ui.Input();
            gameOn = (answer != "" && answer.ToLower() != "n");

        }

        void PlayGame()
        {
            string goal = game.TargetDigits();
            ui.Output("New game:\n");
            //comment out or remove next line to play real games!
            ui.Output("For practice, number is: " + goal + "\n");
            int numberOfGuesses = 0;
            string result;
            do
            {
                string guess = ui.Input();
                numberOfGuesses++;
                result = game.CheckBullAndCow(goal, guess);
                ui.Output(result + "\n");
            } while (result != "BBBB,");

            StreamWriter output = new StreamWriter("result.txt", append: true);
            {
                output.WriteLine(userName + "#&#" + numberOfGuesses);
                output.Close();
            }

            game.HighscoreBoard();

            ui.Output("Correct, it took " + numberOfGuesses + " guesses");

        }







    }

}
