namespace LabbCC
{
    public interface IPlayerDAO
    {
        int GamesPlayed { get; }
        string PlayerName { get; }

        double Average();
        bool Equals(object obj);
        int GetHashCode();
        void UpdatePosition(int guess);
    }
}