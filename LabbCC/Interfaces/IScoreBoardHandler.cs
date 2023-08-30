namespace LabbCC.Interfaces
{
    public interface IScoreBoardHandler
    {
        void PrintScoreBoard(List<PlayerDAO> scoreBoard);
        void Update(List<PlayerDAO> scoreBoard);
    }
}