
namespace LabbCC;

class MainClass
	{
		public static void Main(string[] args)
    {
        IUI ui = new ConsoleIO();
        GameLobby gameLobby = new GameLobby(ui);
        gameLobby.GameMenu();
    }

}