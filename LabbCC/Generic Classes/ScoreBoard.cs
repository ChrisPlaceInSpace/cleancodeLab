
using System.Text;

namespace LabbCC;

public class ScoreBoard : IScoreBoard
{
    private readonly IUI _ui;
    private readonly Filehandler _filehandler;
    public ScoreBoard(Filehandler filehandler, IUI ui)
    {
        _filehandler = filehandler;
        _ui = ui;
    }
    public void UpdateScoreBoard(List<PlayerDAO> players)
    {
        try
        {
            List<string> lines = _filehandler.ReadFile();
            foreach (string line in lines)
            {
                string[] nameAndScore = line.Split(new string[] { _filehandler.TextSeparator }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int score = Convert.ToInt32(nameAndScore[1]);
                PlayerDAO playerData = new PlayerDAO(name, score, _ui);
                int position = players.IndexOf(playerData);

                if (position < 0)
                {
                    players.Add(playerData);
                }
                else
                {
                    UpdatePosition(players[position], playerData.NumberOfGuesses);
                }
            }
            SortScoreboard(players);
        }
        catch(Exception ex) { _ui.Output("Could not update Scoreboard. \n" + ex); }

    }
    public void PrintScoreBoard(List<PlayerDAO> players)
    {
        try
        {
            _ui.Output("Player   games average");
            foreach (PlayerDAO player in players)
            {
                _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", Truncate(player.PlayerName), player.GamesPlayed, CalculateAverage(player)));
            }
        }
        catch (Exception ex) { _ui.Output("Could not print highscore. \n" + ex); }

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
    public void UpdatePosition(PlayerDAO player, int guess)
    {
        try
        {
            player.NumberOfGuesses += guess;
            player.GamesPlayed++;
        }
        catch (Exception ex) { _ui.Output("Could not update position. \n" + ex); }
    }
    public double CalculateAverage(PlayerDAO player)
    {
        try
        {
            return (double)player.NumberOfGuesses / player.GamesPlayed;
        }
        catch (Exception ex) { _ui.Output("Could not calculate average. \n" + ex); return 0; }
    }
    public void SortScoreboard(List<PlayerDAO> players)
    {
        //Sorterar poängtavlan baserat på resultatet av CalculateAverage
        try
        { players.Sort((p1, p2) => CalculateAverage(p1).CompareTo(CalculateAverage(p2))); }
        catch (Exception ex) { _ui.Output("Could not sort. \n" + ex); }
    }
}
