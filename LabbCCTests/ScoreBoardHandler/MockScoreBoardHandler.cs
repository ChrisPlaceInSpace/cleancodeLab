using LabbCC;
using System.Text;

namespace LabbCCTests;

internal class MockScoreBoardHandler : IScoreBoardHandler
{
    private readonly IUI ui;
    private readonly MockFileHandler filehandler;
    public MockScoreBoardHandler(MockFileHandler filehandler, IUI ui)
    {
        this.filehandler = filehandler;
        this.ui = ui;
    }
    public double CalculateAverage(PlayerDAO player)
    {
        return (double)player.NumberOfGuesses / player.GamesPlayed;
    }

    public void PrintScoreBoard(List<PlayerDAO> scoreBoard)
    {
        throw new NotImplementedException();
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
            PlayerDAO playerData = new PlayerDAO(name, score, ui);
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
    }
}
