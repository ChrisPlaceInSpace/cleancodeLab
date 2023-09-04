
using System.Text;

namespace LabbCC;

public class ScoreBoardHandler : IScoreBoardHandler
{
    private readonly IUI ui;
    private readonly Filehandler filehandler;
    public ScoreBoardHandler(Filehandler filehandler, IUI ui)
    {
        this.filehandler = filehandler;
        this.ui = ui;
    }

    public void UpdateScoreBoard(List<PlayerDAO> playerStats)
    {
        try
        {
            List<string> lines = filehandler.ReadFile();
            foreach (string line in lines)
            {
                string[] nameAndScore = line.Split(new string[] { filehandler.TextSeparator }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int score = Convert.ToInt32(nameAndScore[1]);
                PlayerDAO playerData = new PlayerDAO(name, score, ui);
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
        catch(Exception ex) { ui.Output("Could not update Scoreboard. \n" + ex); }

    }

    public void PrintScoreBoard(List<PlayerDAO> playerStats)
    {
        //Sorterar poängtavlan baserat på resultatet av Average
        try
        {playerStats.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));}
        catch (Exception ex) { ui.Output("Could not sort. \n" + ex);}

        try
        {
            ui.Output("Player   games average");
            foreach (PlayerDAO player in playerStats)
            {
                ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.GamesPlayed, player.Average()));
            }
        }
        catch (Exception ex) { ui.Output("Could not print highscore. \n" + ex); }

    }   
        
    public string Truncate(string incomingString)
    {
            int maxLength = 9;
            if (incomingString.Length > maxLength)
            {
                StringBuilder sb = new StringBuilder(incomingString);
                sb.Length = maxLength;
                string truncatedString = sb.ToString();
                return truncatedString;
            }
            return incomingString;
    }
}
