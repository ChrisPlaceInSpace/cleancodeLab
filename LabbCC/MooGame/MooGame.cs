using LabbCC.Interfaces;

namespace LabbCC.MooGame;

public class MooGame : IGame
{
    public IUI ui = new ConsoleIO();

    readonly MooGameLogic mooGameLogic = new MooGameLogic();
    public string GameName { get; set; }
    public MooGame(string gameName)
    {
        GameName = gameName;
    }
    readonly IFilehandler filehandler = new Filehandler("MooGameScore.txt", "#&#");

    public void RunGame()     //Göra denna mer generisk för fler spel?
    {
        IScoreBoardHandler scoreBoardHandler = new ScoreBoardHandler(filehandler);
        bool gameOn = true;
        ui.Clear();
        ui.Output("Enter your user name:\n");
        string userNameInput = ui.Input();
        string userName = scoreBoardHandler.Truncate(userNameInput);
        while (gameOn)
        {
            List<PlayerDAO> playerStats = new List<PlayerDAO>();
            ui.Clear();
            ui.Output("New game:\n");
            int numberOfGuesses = 0;
            numberOfGuesses = mooGameLogic.Logic(numberOfGuesses);
            filehandler.WriteToFile(userName, numberOfGuesses);
            ui.Output($"Correct, it took {numberOfGuesses} guesses\n");
            scoreBoardHandler.UpdateScoreBoard(playerStats);
            scoreBoardHandler.PrintScoreBoard(playerStats);
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
                ui.Clear();
                return false;
            }
            else
                ui.Clear();
            ui.Output("Please enter 'y' to continue or 'n' to quit");

        }
        return false;
    }


}
