namespace LabbCC
{
    public interface IGame
    {
        //public List<PlayerDAO> scoreBoard { get; set; }
        void Game();
        bool Continue(bool gameOn);
        void UpdateScoreBoard();
        void PrintScoreBoard();
        void WriteToFile(string userName, int numberOfGuesses);
    }
}