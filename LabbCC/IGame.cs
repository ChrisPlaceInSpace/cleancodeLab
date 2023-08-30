namespace LabbCC
{
    public interface IGame
    {
        //public List<PlayerDAO> scoreBoard { get; set; }
        string GameName { get; set; }
        void RunGame();
        bool Continue();
        void UpdateScoreBoard();
        void PrintScoreBoard();
        void WriteToFile(string userName, int numberOfGuesses);
    }
}