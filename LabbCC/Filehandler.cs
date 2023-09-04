

namespace LabbCC;

public class Filehandler : IDataHandler
{
    private readonly IUI ui;
    public string TextSeparator { get; set; }
    public string File { get; set; }

    public Filehandler(string file, string textSeparator, IUI ui)
    {
        this.File = file;
        this.TextSeparator = textSeparator;
        this.ui = ui;
    }


    public void WriteToFile(string userName, int numberOfGuesses)
    {
        try
        {
            StreamWriter streamWriter = new StreamWriter(File, append: true);
            {
                streamWriter.WriteLine($"{userName}{TextSeparator}{numberOfGuesses}");
                streamWriter.Close();
            }
        }
        catch (Exception ex)
        {
            ui.Output("Could not write to file\n" + ex);
            throw;
        }
    }

    public List<string> ReadFile()
    {
        try
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
        catch (Exception ex) { ui.Output("Could not read from File. \n" + ex); return null; }
    }

    

}