using LabbCC.Interfaces;
namespace LabbCC.MooGame;


public class GameController : IGameController
{
    public List<IGame> games = new List<IGame>();
    private readonly IUI _ui;
    public GameController(IUI ui) 
    {
        games.Add(new MooGame("Moo", new Filehandler("MooGameScore.txt", "#&#")));
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
                        //Annat spel
                        break;
                    default:
                        _ui.Output("Choose a number for an existing game");
                        break;
                }
            } catch (Exception ex) { Console.WriteLine("Could not run GameSelector \n" + ex); }

        }
    }
    public int SelectedGameByUser()
    {
        _ui.Output("Please select game:\n");
        _ui.Output($"1. {games[0].GameName}");
        _ui.Output("0. Exit menu");
        int.TryParse(_ui.Input(), out int selectGame);
        return selectGame;
    }
}
