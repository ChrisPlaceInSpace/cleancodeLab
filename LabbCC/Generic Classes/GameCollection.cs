namespace LabbCC;
public class GameCollection : IGameCollection
{
    private readonly IUI _ui;
    public GameCollection(IUI ui)
    {
        _ui = ui;
    }
    public List<IGame> Collection()
    {
        try
        {
            List<IGame> games = new List<IGame>
            {
                new MooGame("Moo", new Filehandler("MooGameScore.txt", _ui), _ui),
                new MasterMindGame("MasterMind", new Filehandler("MasterMindScore.txt", _ui), _ui)
            };
            return games;
        }
        catch (Exception ex)
        {
            _ui.Output(ex + " Could not return list of games..");
            return null;
        }
    }
}
