using System.Runtime.InteropServices;

namespace LabbCC;

public class GameController : IGameController
{
    private IUI ui;
    private Game _game;
    public GameController(Game game, IUI iui)
    {
        _game = game;
        ui = iui;
    }
    public void RunGame()
    {
        bool gameOn = true;
        ui.Output("Enter your user name:\n");
        string userName = ui.Input();
        while (gameOn)
        {
            //Val av spel?
            Game(userName);         //If sats eller liknande för val?
            _game.UpdateScoreBoard();
            _game.PrintScoreBoard();
            Continue(gameOn);
        }
    }
    public void Game(string userName)     //Göra denna mer generisk för fler spel?
    {
        string goal = _game.TargetDigits();
        ui.Output("New game:\n");
        //comment out or remove next line to play real games!
        ui.Output("For practice, number is: " + goal + "\n");
        int numberOfGuesses = 0;
        string result;
        do
        {
            string guess = ui.Input();
            numberOfGuesses++;
            result = _game.CheckBullAndCow(goal, guess);
            ui.Output(result + "\n");
        } while (!result.StartsWith("BBBB,"));
        _game.WriteToFile(userName, numberOfGuesses);
        ui.Output($"Correct, it took {numberOfGuesses} guesses\n");
    }
    public bool Continue(bool gameOn)
    {
        ui.Output("\nContinue? \nYes(y) / No(n)");
        string answer = ui.Input();
        gameOn = (answer != "" && answer.ToLower() != "n");
        return gameOn;
    }


}
