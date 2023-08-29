using System.Runtime.InteropServices;

namespace LabbCC;

public class GameController : IGameController
{
    public List<IGame> games = new List<IGame>();
    IUI ui = new ConsoleIO();
    public GameController()
    {
        games.Add(new MooGame(ui, "Moo"));
    }
    public void SelectGame()
    {
        bool running = true;
        while (running)
        {
            ui.Output("Please select game:\n");
            ui.Output($"1. {games[0].GameName}");
            ui.Output("0. Exit menu");
            int.TryParse(ui.Input(), out int selectGame); 
            switch (selectGame)
            {
                case 0:
                    ui.ExitGame();
                    break;
                case 1:
                    games[0].RunGame();
                    break;
                case 2:
                    //Annat spel
                    break;
                default:
                    ui.Output("Choose a number for an existing game");
                    break;
            }

        }
    }

    //public void RunGame()
    //{
    //    SelectGame();

    //    //Val av spel?
    //   //games[0].Game();         //If sats eller liknande för val?
    //                             //games[0].UpdateScoreBoard();
    //                             //games[0].PrintScoreBoard();
    //                             //games[0].Continue(gameOn); //Fråga Benjamin vafan?!

    //}



}
