using System.Runtime.InteropServices;

namespace LabbCC;

public class GameController : IGameController
{
    public List<IGame> games = new List<IGame>();
    IUI ui = new ConsoleIO();
    public GameController()
    {
       games.Add(new MooGame(ui));
    }
    public void SelectGame()
    {

    }

    public void RunGame()
    {
        SelectGame();
        bool gameOn = true;
        while (gameOn)
        {
            //Val av spel?
            games[0].Game();         //If sats eller liknande för val?
            games[0].UpdateScoreBoard();
            games[0].PrintScoreBoard();
            games[0].Continue(gameOn); //Fråga Benjamin vafan?!
        }
    }



}
