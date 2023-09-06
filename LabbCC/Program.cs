namespace LabbCC;

class MainClass
	{
		public static void Main(string[] args)
    {
        //Hela programmet använder sig av detta UI
        //Vill du ha annat UI så får du skapa det senare
        IUI ui = new ConsoleIO();
        GameLobby gameLobby = new GameLobby(ui);
        gameLobby.GameMenu();
    }
}