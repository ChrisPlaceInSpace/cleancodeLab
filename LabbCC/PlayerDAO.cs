using LabbCC.Interfaces;

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

    public void UpdatePosition(int guess)
    {
        NumberOfGuesses += guess;
        GamesPlayed++;
    }

    public double Average()
    {
        return (double)NumberOfGuesses / GamesPlayed;
    }


    public override bool Equals(Object obj) //Fråga Benji
    {
        PlayerDAO other = (PlayerDAO)obj;
        return PlayerName.Equals(other.PlayerName);
    }


    public override int GetHashCode()   //Fråga Benjamin om funktion.
    {
        return PlayerName.GetHashCode();
    }
}
