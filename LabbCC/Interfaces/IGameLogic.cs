namespace LabbCC;    

public interface IGameLogic
{
    string UserNameInput();
    void PrintGameIntructions();
    string GoalGenerator();
    int PlayLogic();
    int CountHit(string goal, string guess);
    int CountMiss(string goal, string guess);
    string ResultFromGuess(string goal, string guess);
    bool Continue();
}