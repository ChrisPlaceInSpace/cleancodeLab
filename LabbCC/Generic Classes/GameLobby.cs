using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace LabbCC;
public class GameLobby : IGameLobby
{
    private readonly IUI _ui;
    private readonly IGameCollection<IGame> _gameCollection;
    public GameLobby(IUI ui)
    {
        _ui = ui;
        _gameCollection = new GameCollection<IGame>(_ui);
    }
    public void GameMenu()
    {
        _gameCollection.AddGames();
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
            var games = _gameCollection.GetGames();
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
        if (select > 0 && select <= _gameCollection.GetGames().Count)
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
            var games = _gameCollection.GetGames();
            IGame game = games[select - 1];
            game.RunGame();
        }
        catch (Exception ex)
        {
            _ui.Output(ex + " Could not select game.");
        }
    }
}

