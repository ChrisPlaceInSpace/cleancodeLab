

namespace LabbCC;

public class Filehandler : IDataHandler
{
    //private readonly IUI _ui;
    public string TextSeparator { get; set; }
    public string File { get; set; }
    public Filehandler(string file)
    {
        this.File = file;
        TextSeparator = "#&#";
    }
    public void WriteToFile(string userName, int numberOfGuesses)
    {
            StreamWriter streamWriter = new StreamWriter(File, append: true);
            {
                streamWriter.WriteLine($"{userName}{TextSeparator}{numberOfGuesses}");
                streamWriter.Close();
            }
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
}