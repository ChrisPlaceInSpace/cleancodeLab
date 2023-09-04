using LabbCC;

namespace LabbCCTests;

public class MockPlayerDAO
{
    public int GamesPlayed { get; set; }

    public string PlayerName { get; set; } = string.Empty;
    public int NumberOfGuesses { get; set; }
    public MockPlayerDAO(int gamesPlayed, string playerName, int numberOfGuesses)
    {
        this.GamesPlayed = gamesPlayed;
        this.PlayerName = playerName;
        this.NumberOfGuesses = numberOfGuesses;
    }
}


