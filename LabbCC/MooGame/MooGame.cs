namespace LabbCC;

public class MooGame : IGame
{
    private readonly IUI _ui;
    private readonly Filehandler _filehandler;
    public string GameName { get; set; }
    public MooGame(string gameName, Filehandler filehandler, IUI ui)
    {
        GameName = gameName;
        _filehandler = filehandler;
        _ui = ui;
    }
    IGameLogic mooGameLogic => new MooGameLogic(_ui);
    public void RunGame()
    {
        try
        {
            IScoreBoard scoreBoard = new ScoreBoard(_filehandler, _ui);
            List<PlayerDAO> playerStats = new List<PlayerDAO>();
            string userName = mooGameLogic.UserNameInput();
            bool gameOn = true;
            while (gameOn)
            {
                mooGameLogic.PrintGameIntructions();
                int numberOfGuesses = mooGameLogic.PlayLogic();
                _filehandler.WriteToFile(userName, numberOfGuesses);
                scoreBoard.UpdateScoreBoard(playerStats);
                scoreBoard.PrintScoreBoard(playerStats);
                gameOn = mooGameLogic.Continue();
            }
        }
        catch (Exception ex)
        {
            _ui.Output("Game could not run. \n" + ex);
        }
    }
}
