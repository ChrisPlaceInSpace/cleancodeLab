using LabbCC;
using LabbCC.Interfaces;
using System.Diagnostics;

namespace LabbCC.MooGame
{
    class MainClass
	{
		public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
                GameController gameController = new GameController(ui);
                gameController.SelectGame();
        }

    }

}