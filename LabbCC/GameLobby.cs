namespace LabbCC;
public class GameLobby : IGameLobby
{
    private readonly IUI _ui;
    public GameLobby(IUI ui)
    {

        _ui = ui;
    }

    public void GameMenu()
    {
        bool running = true;
        while (running)
        {
            try
            {
                int select = PrintMenuOptions();
                SelectedGame(select);

            }
            catch (Exception ex) { _ui.Output("Could not run GameSelector \n" + ex); }

        }
    }
    public int PrintMenuOptions()
    {
        try
        {
            var games = GameCollection();
            var gameNumber = 1;
            _ui.Output("Please select game:\n");
            foreach (var game in games)
            {
                _ui.Output($"{gameNumber}. {game.GameName}");
                gameNumber++;
            }

            _ui.Output("0. Exit menu");
            int.TryParse(_ui.Input(), out int selectGame);
            return selectGame;

        }
        catch (Exception ex)
        {
            _ui.Output(ex + " Could not print menu.");
            return 0;
        }
    }

    public List<IGame> GameCollection()
    {
        try
        {
            const string textSeparator = "#&#";
            List<IGame> games = new List<IGame>
                {
                    new MooGame("Moo", new Filehandler("MooGameScore.txt", textSeparator, _ui), _ui),
                    new MasterMindGame("MasterMind", new Filehandler("MasterMindScore.txt", textSeparator, _ui), _ui)
                };

            return games;

        }
        catch (Exception ex)
        {
            _ui.Output(ex + " Could not return list of games..");
            return null;
        }
    }

    public void SelectedGame(int select)
    {
        try
        {
            var games = GameCollection();
            if (select > 0 && select <= games.Count())
            {
                IGame game = games[select - 1];
                game.RunGame();
            }
            else if (select == 0)
            {
                _ui.ExitGame();
            }
            else
            {
                _ui.Output("Choose a number for an existing game");
            }

        }
        catch (Exception ex)
        {
            _ui.Output(ex + " Could not select game.");
        }
    }
    //public int SelectOptions()
    //{
    //    int selectedOption =  > 0 && select <= games.Count()
    //    return 
    //}

}
