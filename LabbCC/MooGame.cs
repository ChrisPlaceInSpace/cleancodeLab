using System.Net.Http.Headers;
using System.Xml.Linq;
using LabbCC.Interfaces;

namespace LabbCC;

public class MooGame : IGame
{
    public IUI ui = new ConsoleIO();
    IGameController controller;
    MooGameLogic mooGameLogic;
    public string GameName { get; set; }
    public MooGame(string gameName)
    {
        GameName = gameName;
    }
    IFilehandler filehandler = new Filehandler("MooGameScore.txt", "#&#");

    public void RunGame()     //Göra denna mer generisk för fler spel?
    {
        IScoreBoardHandler scoreBoardHandler = new ScoreBoardHandler(filehandler);
        bool gameOn = true;
        ui.Clear();
        ui.Output("Enter your user name:\n");
        string userName = ui.Input();
        while (gameOn)
        {
            List<PlayerDAO> playerStats = new List<PlayerDAO>();
            ui.Clear();
            ui.Output("New game:\n");
            int numberOfGuesses = 0;
            string result = "";
            mooGameLogic.Logic(numberOfGuesses, result);
            filehandler.WriteToFile(userName, numberOfGuesses);
            ui.Output($"Correct, it took {numberOfGuesses} guesses\n");
            scoreBoardHandler.Update(playerStats);
            scoreBoardHandler.PrintScoreBoard(playerStats);
            gameOn = controller.Continue();
        }
    }

    

}
