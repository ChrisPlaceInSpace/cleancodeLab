namespace LabbCC;

public interface IDataHandler
{
    public string File { get; set;  }
    List<string> ReadFile();
    void WriteToFile(string userName, int numberOfGuesses);
}