namespace LabbCC;
public class GameLobby : IGameLobby
{

    private readonly IUI _ui;
    public GameLobby(IUI ui)
    {

        _ui = ui;
    }

    public void SelectGame()
    {
        bool running = true;
        while (running)
        {
            try
            {
                GameCreator creator = new GameCreator(_ui);
                int select = SelectedGameByUser();
                creator.Games(select);
                //switch (SelectedGameByUser())
                //{
                //    case 0:
                //        _ui.ExitGame();
                //        break;
                //    case 1:
                //        games[0].RunGame();
                //        break;
                //    case 2:
                //        games[1].RunGame();
                //        break;
                //    //case 3:
                //    //Annat spel
                //    //    break;
                //    default:
                //        _ui.Output("Choose a number for an existing game");
                //        break;
                //}
            }
            catch (Exception ex) { _ui.Output("Could not run GameSelector \n" + ex); }

        }
    }
    public int SelectedGameByUser()
    {
        _ui.Output("Please select game:\n");
        //_ui.Output($"1. {games[0].GameName}");
        //_ui.Output($"2. {games[1].GameName}");
        _ui.Output("0. Exit menu");
        int.TryParse(_ui.Input(), out int selectGame);
        return selectGame;
    }
    public class GameCreator
    {

        private readonly IUI _ui;
        public GameCreator(IUI ui)
        {
            _ui = ui;
        }

        public void Games(int select)
        {
            List<IGame> games = new List<IGame>
            {
                new MooGame("Moo", new Filehandler("MooGameScore.txt", "#&#", _ui), _ui),
                new MasterMindGame("MasterMind", new Filehandler("MasterMindScore.txt", "#&#", _ui), _ui)
            };
            foreach (var game in games)
            {
                if (select == games.Count - 1)
                {
                    game.RunGame();
                }
            }
        }

    }
}
