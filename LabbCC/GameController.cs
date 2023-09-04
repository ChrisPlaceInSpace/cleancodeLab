namespace LabbCC;
public class GameController : IGameController
{
    private readonly List<IGame> games = new List<IGame>();
    private readonly IUI _ui;
    public GameController(IUI ui) 
    {
        games.Add(new MooGame("Moo", new Filehandler("MooGameScore.txt", "#&#", ui), ui));
        games.Add(new MasterMindGame("MasterMind", new Filehandler("MasterMindScore.txt", "#&#", ui), ui));
        _ui = ui;
    }
    
    public void SelectGame()
    {
        bool running = true;
        while (running)
        {
            try
            {
                              
                switch (SelectedGameByUser())
                {
                    case 0:
                        _ui.ExitGame();
                        break;
                    case 1:
                        games[0].RunGame();
                        break;
                    case 2:
                        games[1].RunGame();
                        break;
                    case 3:
                        //Annat spel
                        break;
                    default:
                        _ui.Output("Choose a number for an existing game");
                        break;
                }
            } catch (Exception ex) { _ui.Output("Could not run GameSelector \n" + ex); }

        }
    }
    public int SelectedGameByUser()
    {
        _ui.Output("Please select game:\n");
        _ui.Output($"1. {games[0].GameName}");
        _ui.Output($"2. {games[1].GameName}");
        _ui.Output("0. Exit menu");
        int.TryParse(_ui.Input(), out int selectGame);
        return selectGame;
    }
}
