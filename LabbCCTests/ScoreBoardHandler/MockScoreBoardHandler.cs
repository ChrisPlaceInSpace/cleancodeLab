using LabbCC;
using System.Text;

namespace LabbCCTests;

internal class MockScoreBoard : IScoreBoard
{
    private readonly IUI _ui;
    private readonly MockFileHandler filehandler;
    public MockScoreBoard(MockFileHandler filehandler, IUI ui)
    {
        this.filehandler = filehandler;
        this._ui = ui;
    }
    public double CalculateAverage(PlayerDAO player)
    {
        return (double)player.NumberOfGuesses / player.GamesPlayed;
    }

    public void PrintScoreBoard(List<PlayerDAO> scoreBoard)
    {
        throw new NotImplementedException();
    }

    public void SortScoreboard(List<PlayerDAO> players)
    {
        //Sorterar poängtavlan baserat på resultatet av CalculateAverage
        try
        { players.Sort((p1, p2) => CalculateAverage(p1).CompareTo(CalculateAverage(p2))); }
        catch (Exception ex) { _ui.Output("Could not sort. \n" + ex); }
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
        player.NumberOfGuesses += guess;
        player.GamesPlayed++;
    }

    public void UpdateScoreBoard(List<PlayerDAO> players)
    {
        List<string> lines = filehandler.ReadFile();
        foreach (string line in lines)
        {
            string[] nameAndScore = line.Split(new string[] { filehandler.TextSeparator }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int score = Convert.ToInt32(nameAndScore[1]);
            PlayerDAO playerData = new PlayerDAO(name, score);
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
}
