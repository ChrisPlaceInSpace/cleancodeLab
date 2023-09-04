
namespace LabbCC;

public class MooGame : IGame
{
    private readonly IUI ui;
    private readonly Filehandler _filehandler;

    public string GameName { get; set; }
    public MooGame(string gameName, Filehandler filehandler, IUI ui)
    {
        GameName = gameName;
        _filehandler = filehandler;
        this.ui = ui;
    }
    IGameLogic mooGameLogic => new MooGameLogic(ui);

    public void RunGame()
    {
        try
        {
            
            IScoreBoardHandler scoreBoardHandler = new ScoreBoardHandler(_filehandler, ui);
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
                numberOfGuesses = mooGameLogic.PlayLogic(numberOfGuesses);
                _filehandler.WriteToFile(userName, numberOfGuesses);
                ui.Output($"Correct, it took {numberOfGuesses} guesses\n");
                scoreBoardHandler.UpdateScoreBoard(playerStats);
                scoreBoardHandler.PrintScoreBoard(playerStats);
                gameOn = Continue();
            }
        }
        catch (Exception ex)
        {
            ui.Output("Game could not run. \n" + ex);
        }
    }
    public bool Continue()
    {
        try
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
        catch (Exception ex) { ui.Output("Could not continue to run properly. \n" + ex); return false; }
    }


}
