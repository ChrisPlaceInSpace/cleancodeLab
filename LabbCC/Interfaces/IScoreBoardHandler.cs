namespace LabbCC.Interfaces
{
    public interface IScoreBoardHandler
    {
        void PrintScoreBoard(List<PlayerDAO> scoreBoard);
        void UpdateScoreBoard(List<PlayerDAO> scoreBoard);
        string Truncate(string incomingString);
        
    }
}