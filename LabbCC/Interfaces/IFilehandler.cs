namespace LabbCC;

public interface IDataHandler   //Byta namn till DataHandler?
{
    public string File { get; set;  }
    List<string> ReadFile();
    void WriteToFile(string userName, int numberOfGuesses);
}