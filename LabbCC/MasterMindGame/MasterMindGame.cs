
namespace LabbCC;

internal class MasterMindGame : IGame
{
    private readonly IUI ui;
    private readonly Filehandler filehandler;
    public string GameName { get; set; }

    public MasterMindGame(string gameName, Filehandler filehandler, IUI ui)
    {
        this.GameName = gameName;
        this.filehandler = filehandler;
        this.ui = ui;
    }

    IGameLogic masterMindGameLogic => new MasterMindGameLogic(ui);

    public void RunGame()
    {
        try
        {

            IScoreBoardHandler scoreBoardHandler = new ScoreBoardHandler(filehandler, ui);
            bool gameOn = true;
            ui.Clear();
            ui.Output("Enter your user name:\n");
            string userNameInput = ui.Input();
            string userName = scoreBoardHandler.Truncate(userNameInput);
            while (gameOn)
            {
                List<PlayerDAO> playerStats = new List<PlayerDAO>();
                ui.Clear();
                ui.Output("Guess the Colors:");
                ui.Output("R(Red), G(Green), B(Blue), Y(Yellow), W(White), P(Pink)\n");
                ui.Output("New game:\n");
                int numberOfGuesses = 0;
                numberOfGuesses = masterMindGameLogic.PlayLogic(numberOfGuesses);
                filehandler.WriteToFile(userName, numberOfGuesses);
                ui.Output($"Correct, it took {numberOfGuesses} guesses\n");
                scoreBoardHandler.UpdateScoreBoard(playerStats);
                scoreBoardHandler.PrintScoreBoard(playerStats);
                gameOn = Continue();
            }
        }
        catch (Exception ex)
        {
            ui.Output("Game could not run. \n" + ex);
        };
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
        catch (Exception ex) { ui.Output("Could not continue to run properly. \n" + ex); return false; };
    }
}
