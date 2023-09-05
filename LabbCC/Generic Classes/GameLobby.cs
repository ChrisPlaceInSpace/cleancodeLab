using System.Reflection.Metadata.Ecma335;

namespace LabbCC;
public class GameLobby : IGameLobby
{
    private readonly IUI _ui;
    IGameCollection _games;
    public GameLobby(IUI ui)
    {
        _ui = ui;
        _games = new GameCollection(ui);
    }
    public void GameMenu()
    {
        bool running = true;
        while (running)
        {
            try
            {
                int select = PrintMenuOptions();
                OptionSelector(select);
            }
            catch (Exception ex) { _ui.Output("Could not run GameSelector \n" + ex); }
        }
    }
    public int PrintMenuOptions()
    {
        try
        {
            var games = _games.Collection();
            var gameNumber = 1;
            _ui.Output("Please select game:\n");
            foreach (var game in games)
            {
                _ui.Output($"{gameNumber}. {game.GameName}");
                gameNumber++;
            }
            _ui.Output("0. Exit menu");
            int selectGame = 0;
            while (!int.TryParse(_ui.Input(), out selectGame))
            {
                _ui.Output("Please enter a number");
            }
            return selectGame;
        }
        catch (Exception ex)
        {
            _ui.Output(ex + " Could not print menu.");
            return 0;
        }
    }
    public void OptionSelector(int select)
    {
        if (select > 0 && select <= _games.Collection().Count)
        {
            SelectedGame(select);
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
    public void SelectedGame(int select)
    {
        try
        {
            var games = _games.Collection();
            IGame game = games[select - 1];
            game.RunGame();
        }
        catch (Exception ex)
        {
            _ui.Output(ex + " Could not select game.");
        }
    }
}

