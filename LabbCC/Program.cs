using LabbCC;
using System.Diagnostics;

namespace MooGame
{
    class MainClass
	{
		public static void Main(string[] args)
        {

            IUI ui = new ConsoleIO();
            Game game = new Game(ui);
            GameController gameController = new GameController(game, ui);
            //Debug.Write(game.ToString());
            //Debug.WriteLine("Test");
            gameController.RunGame();
            
        }

    }

}