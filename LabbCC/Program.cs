using LabbCC;
using LabbCC.Interfaces;
using System.Diagnostics;

namespace MooGame
{
    class MainClass
	{
		public static void Main(string[] args)
        {
                        
            GameController gameController = new GameController();            
            gameController.SelectGame();
            
        }

    }

}