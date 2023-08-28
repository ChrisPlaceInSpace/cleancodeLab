namespace LabbCC;

public class PlayerDAO : IPlayerDAO
{
    public string PlayerName { get; private set; }
    public int GamesPlayed { get; private set; }
    int numberOfGuesses;

    public PlayerDAO(string name, int guess) 
    {
        PlayerName = name;
        GamesPlayed = 1;
        numberOfGuesses = guess;
    }

    public void UpdatePosition(int guess)
    {
        numberOfGuesses += guess;
        GamesPlayed++;
    }

    public double Average()
    {
        return (double)numberOfGuesses / GamesPlayed;
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
