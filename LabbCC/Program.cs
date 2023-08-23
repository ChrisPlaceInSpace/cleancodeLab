using LabbCC;
using System.Diagnostics;

namespace MooGame
{
    class MainClass
	{

		public static void Main(string[] args)
        {
            Game game = new Game();
            //Debug.Write(game.ToString());
            //Debug.WriteLine("Test");
            game.RunGame();
            
        }

    }

}