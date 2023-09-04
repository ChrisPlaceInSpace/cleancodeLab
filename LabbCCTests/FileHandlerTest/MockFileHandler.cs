using LabbCC;

namespace LabbCCTests;

internal class MockFileHandler : IDataHandler
{
    public string File { get; set; }
    public string Separator { get; set; }   //Gör internal?

    public MockFileHandler(string file, string separator)
    {
        this.File = file;
        this.Separator = separator;
    }

    public List<string> ReadFile()
    {
        StreamReader streamReader = new StreamReader(File);
        string line;
        List<string> lines = new List<string>();
        //För varje rad i filen, lägg till strängen i listan
        while ((line = streamReader.ReadLine()) != null)
        {
            lines.Add(line);
        }
        streamReader.Close();
        return lines;
    }

    public void WriteToFile(string userName, int numberOfGuesses)
    {
        StreamWriter streamWriter = new StreamWriter(File, append: true);
        {
            streamWriter.WriteLine($"{userName}{Separator}{numberOfGuesses}");
            streamWriter.Close();
        }
        
    }
}
