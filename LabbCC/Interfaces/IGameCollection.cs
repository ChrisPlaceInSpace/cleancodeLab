namespace LabbCC
{
    public interface IGameCollection<IGame>
    {
        void AddGames();
        List<IGame> GetGames();
    }
}