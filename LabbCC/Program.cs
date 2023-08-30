using LabbCC;
using LabbCC.Interfaces;
using System.Diagnostics;

namespace MooGame
{
    class MainClass
	{
		public static void Main(string[] args)
        {

            IUI ui = new ConsoleIO();
            GameController gameController = new GameController();
            //Debug.Write(game.ToString());
            //Debug.WriteLine("Test");
            gameController.SelectGame();
            
        }

    }

}