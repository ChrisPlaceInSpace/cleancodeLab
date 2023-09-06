namespace LabbCC;
public class GameCollection<T> : IGameCollection<IGame>
{
    private readonly IUI _ui;
    private readonly List<IGame> _games;
    public GameCollection(IUI ui)
    {
        _ui = ui;
        _games = new List<IGame>();
    }
    public List<IGame> GetGames()
    {
        try
        {
            return _games.Cast<IGame>().ToList();
        }
        catch (Exception ex)
        {
            _ui.Output(ex + " Could not return list of games..");
            return null;
        }
    }
    public void AddGames()
    {
        _games.AddRange(new List<IGame>
        {
            new MooGame("Moo", new Filehandler("MooGameScore.txt"), _ui),
            new MasterMindGame("MasterMind", new Filehandler("MasterMindScore.txt"), _ui)
        });
    }
} 