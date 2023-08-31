namespace LabbCC.Interfaces;

public interface IGameLogic
{
    int PlayLogic(int numberOfGuesses);
    string GoalGenerator();
}