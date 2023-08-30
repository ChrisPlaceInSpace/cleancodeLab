using LabbCC.Interfaces;

namespace LabbCC;

internal class ConsoleIO : IUI
{
    public void Clear()
    {
        Console.Clear();
    }

    public void ExitGame()
    {
        System.Environment.Exit(0);
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
