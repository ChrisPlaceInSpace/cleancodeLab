namespace LabbCC;

internal class MasterMindGame : IGame
{
    private readonly IUI _ui;
    private readonly Filehandler _filehandler;
    public string GameName { get; set; }
    public MasterMindGame(string gameName, Filehandler filehandler, IUI ui)
    {
        this.GameName = gameName;
        _filehandler = filehandler;
        _ui = ui;
    }
    IGameLogic masterMindGameLogic => new MasterMindGameLogic(_ui);
    public void RunGame()
    {
        try
        {
            IScoreBoard scoreBoard = new ScoreBoard(_filehandler, _ui);
            List<PlayerDAO> playerStats = new List<PlayerDAO>();
            string userName = masterMindGameLogic.UserNameInput();
            bool gameOn = true;
            while (gameOn)
            {
                masterMindGameLogic.PrintGameIntructions();
                int numberOfGuesses = masterMindGameLogic.PlayLogic();
                try
                {
                _filehandler.WriteToFile(userName, numberOfGuesses);
                }
                catch (Exception ex) { _ui.Output(ex.ToString()); }
                scoreBoard.UpdateScoreBoard(playerStats);
                scoreBoard.PrintScoreBoard(playerStats);
                gameOn = masterMindGameLogic.Continue();
            }
        }
        catch (Exception ex)
        {
            _ui.Output("Game could not run. \n" + ex);
        };
    }

}
