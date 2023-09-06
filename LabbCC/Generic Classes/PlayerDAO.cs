
namespace LabbCC;

public class PlayerDAO : IPlayerDAO
{
    public int GamesPlayed { get; set; }
    public string PlayerName { get; set; }
    public int NumberOfGuesses { get; set; }
    public PlayerDAO(string name, int guess) 
    {
        GamesPlayed = 1;
        PlayerName = name;
        NumberOfGuesses = guess;
    }
    public override bool Equals(Object obj)
    {
            PlayerDAO other = (PlayerDAO)obj;
            return PlayerName.Equals(other.PlayerName); 
    }
    public override int GetHashCode()
    {
            return PlayerName.GetHashCode(); 
    }
}
