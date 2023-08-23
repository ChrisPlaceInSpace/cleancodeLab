namespace LabbCC;

internal class ConsoleIO : IUI
{
    public string Input()
    {
        return Console.ReadLine();
    }

    public void Output(string s)
    {
        Console.WriteLine(s);
    }
}
