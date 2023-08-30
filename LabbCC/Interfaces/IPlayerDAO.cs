namespace LabbCC.Interfaces
{
    public interface IPlayerDAO
    {
        public int GamesPlayed { get; set; }
        string PlayerName { get; }
        int NumberOfGuesses { get; }

        double Average();
        bool Equals(object obj);
        //int GetHashCode();
        void UpdatePosition(int guess);
    }
}