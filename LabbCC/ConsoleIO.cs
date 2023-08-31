using LabbCC.Interfaces;

namespace LabbCC;

public class ConsoleIO : IUI
{
    public void Clear()
    {
        Console.Clear();
    }

    public void ExitGame()
    {
        Environment.Exit(0);
    }

    public string Input()
    {
        return Console.ReadLine();
    }

    public void Output(string s)
    {
        Console.WriteLine(s);
    }
}
