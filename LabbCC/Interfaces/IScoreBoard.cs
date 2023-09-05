namespace LabbCC;

public interface IScoreBoard
{
    void PrintScoreBoard(List<PlayerDAO> scoreBoard);
    void UpdateScoreBoard(List<PlayerDAO> scoreBoard);
    string Truncate(string incomingString);
    void UpdatePosition(PlayerDAO player, int guess);
    double CalculateAverage(PlayerDAO player);
    void SortScoreboard(List<PlayerDAO> players);
}