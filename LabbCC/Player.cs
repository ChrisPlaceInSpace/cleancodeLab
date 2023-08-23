namespace LabbCC;

public class Player
{
    public string Name { get; private set; }
    public int GamesPlayed { get; private set; }    //Ändra till GamesPlayed
    int totalGuess;     //Ändra till numberOfGuesses

    public Player(string name, int guesses)
    {
        this.Name = name;
        GamesPlayed = 1;
        totalGuess = guesses;
    }

    public void Update(int guesses)
    {
        totalGuess += guesses;
        GamesPlayed++;
    }

    public double Average()
    {
        return (double)totalGuess / GamesPlayed;
    }


    public override bool Equals(Object p)
    {
        return Name.Equals(((Player)p).Name);
    }
    

    //public override int GetHashCode()
    //{
    //    return Name.GetHashCode();
    //}
}
