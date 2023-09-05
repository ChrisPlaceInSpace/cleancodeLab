using System.Runtime.CompilerServices;

namespace LabbCC;

public abstract class GameLogic : IGameLogic
{
    private readonly IUI _ui;
    public GameLogic(IUI ui)
    {
        _ui = ui;
    }
    public string UserNameInput()
    {
        _ui.Clear();
        _ui.Output("Enter your user name:\n");
        string userName = _ui.Input();
        return userName;
    }
    public abstract void PrintGameIntructions();
    public abstract int PlayLogic();
    public abstract string GoalGenerator();
    public abstract int CountHit(string goal, string guess);
    public abstract int CountMiss(string goal, string guess);
    public abstract string ResultFromGuess(string goal, string guess);
    public bool Continue()
    {
        try
        {

            bool runLoop = true;
            while (runLoop)
            {
                _ui.Output("\nContinue? \nYes(y) / No(n)");
                string answer = _ui.Input();
                if (answer.ToLower() == "y")
                {
                    return true;
                }
                else if (answer == "n".ToLower())
                {
                    _ui.Clear();
                    return false;
                }
                else
                    _ui.Clear();
                _ui.Output("Please enter 'y' to continue or 'n' to quit");

            }
            return false;
        }
        catch (Exception ex) { _ui.Output("Could not continue to run properly. \n" + ex); return false; }
    }
}
