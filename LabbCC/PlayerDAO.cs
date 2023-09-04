
namespace LabbCC;

public class PlayerDAO : IPlayerDAO
{
    private readonly IUI ui;
    public int GamesPlayed { get; set; }
    public string PlayerName { get; set; }
    
    public int NumberOfGuesses { get; set; }

    public PlayerDAO(string name, int guess, IUI ui) 
    {
        GamesPlayed = 1;
        PlayerName = name;
        NumberOfGuesses = guess;
        this.ui = ui;
    }

    public override bool Equals(Object obj)
    {
        try
        {
            PlayerDAO other = (PlayerDAO)obj;
            return PlayerName.Equals(other.PlayerName);
        }
        catch (Exception ex) { ui.Output("Could not compare player in scoreboard. \n" + ex); return false; }
    }

    public override int GetHashCode()
    {
        try
        {
            return PlayerName.GetHashCode();
        }
        catch (Exception ex) { ui.Output("Could not make Hashcode. ???? Huh? If you find this, you win! \n" + ex); return 0; }
    }
}
