using LabbCC;

namespace LabbCCTests;

public class MockPlayerDAO : IPlayerDAO
{
    public int GamesPlayed { get; set; }

    public string PlayerName { get; set; } = string.Empty;
    public int NumberOfGuesses { get; set; }
    public double Average()
    {
        return (double)NumberOfGuesses / GamesPlayed;
    }

    public void UpdatePosition(int guess)
    {
        NumberOfGuesses += guess;
        GamesPlayed++;
    }
}
