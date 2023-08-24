namespace LabbCC;

public class Player
{
    public string Name { get; private set; }
    public int GamesPlayed { get; private set; }
    int numberOfGuesses;

    public Player(string name, int guess)
    {
        Name = name;
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
        Player other = (Player)obj;
        return Name.Equals(other.Name);
    }


    public override int GetHashCode()   //Fråga Benjamin om funktion.
    {
        return Name.GetHashCode();
    }
}
