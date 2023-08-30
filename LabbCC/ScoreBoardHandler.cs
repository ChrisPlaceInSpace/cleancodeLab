using LabbCC.Interfaces;

namespace LabbCC;

public class ScoreBoardHandler : IScoreBoardHandler
{
    private IUI ui = new ConsoleIO();
    IFilehandler filehandler;
    public ScoreBoardHandler(IFilehandler filehandler)
    {
        this.filehandler = filehandler;
    }

    public void Update(List<PlayerDAO> playerStats)
    {
        List<string> lines = filehandler.Read();
        foreach (string line in lines)
        {
            string[] nameAndScore = line.Split(new string[] { filehandler.Separator }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int score = Convert.ToInt32(nameAndScore[1]);
            PlayerDAO playerData = new PlayerDAO(name, score);
            int position = playerStats.IndexOf(playerData);

            if (position < 0)
            {
                playerStats.Add(playerData);
            }
            else
            {
                playerStats[position].UpdatePosition(playerData.NumberOfGuesses);
            }
        }
    }

    public void PrintScoreBoard(List<PlayerDAO> playerStats)
    {
        //Sorterar poängtavlan baserat på resultatet av Average
        playerStats.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

        ui.Output("Player   games average");
        foreach (PlayerDAO player in playerStats)
        {
            ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.GamesPlayed, player.Average()));
        }

    }
}
