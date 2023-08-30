using System.IO;
using LabbCC.Interfaces;

namespace LabbCC;

public class Filehandler : IFilehandler
{
    private IUI ui = new ConsoleIO();
    public string Separator { get; set; }
    public string File { get; set; }

    public Filehandler(string file, string separator)
    {
        this.File = file;
        this.Separator = separator;
    }


    public void WriteToFile(string userName, int numberOfGuesses)
    {
        try
        {
            StreamWriter streamWriter = new StreamWriter(File, append: true);
            {
                streamWriter.WriteLine($"{userName}{Separator}{numberOfGuesses}");
                streamWriter.Close();
            }
        }
        catch (Exception e)
        {
            ui.Output("Could not write to file\n" + e.ToString());
            throw;
        }
    }

    public List<string> Read()
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

    //public void ReadAndUpdateScoreBoard(List<PlayerDAO> scoreBoard)
    //{
    //    StreamReader streamReader = new StreamReader(file);
    //    string line;
    //    while ((line = streamReader.ReadLine()) != null)
    //    {
    //        string[] nameAndScore = line.Split(new string[] { separator }, StringSplitOptions.None);
    //        string name = nameAndScore[0];
    //        int score = Convert.ToInt32(nameAndScore[1]);
    //        PlayerDAO playerData = new PlayerDAO(name, score);
    //        int position = scoreBoard.IndexOf(playerData);
    //        //OM spelaren inte redan finns på poängtavlan så läggs det till en ny,
    //        //ANNARS uppdateras det gamla resultatet.
    //        if (position < 0)
    //        {
    //            scoreBoard.Add(playerData);
    //        }
    //        else
    //        {
    //            scoreBoard[position].UpdatePosition(score);
    //        }
    //    }
    //    streamReader.Close();

    //}