namespace LabbCC.Interfaces;

public interface IGameLogic
{
    int Logic(int numberOfGuesses);
    string GoalGenerator();
}