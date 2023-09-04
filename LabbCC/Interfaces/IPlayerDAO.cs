namespace LabbCC;

public interface IPlayerDAO
{
    public int GamesPlayed { get; set; }
    string PlayerName { get; }
    int NumberOfGuesses { get; }
}