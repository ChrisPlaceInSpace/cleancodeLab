namespace LabbCC;    

public interface IGameLogic
{
    int PlayLogic(int numberOfGuesses);
    string GoalGenerator();
    string GameStringBuilder(string goal, string guess);
    int CountHit(string goal, string guess);
    int CountMiss(string goal, string guess);
}