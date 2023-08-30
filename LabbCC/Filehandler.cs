namespace LabbCC;

public class Filehandler
{
    private IUI ui;
    string separator = "#&#";
    string file = "result.txt";


    public Filehandler(IUI ui)
    {
            this .ui = ui;
    }

    public void WriteToFile(string userName, int numberOfGuesses)
    {
        try
        {
            StreamWriter streamWriter = new StreamWriter(file, append: true);
            {
                streamWriter.WriteLine($"{userName}{separator}{numberOfGuesses}");
                streamWriter.Close();
            }
        }
        catch (Exception e)
        {
            ui.Output("Could not write to file\n" + e.ToString());
            throw;
        }
    }
    public void ReadAndUpdateScoreBoard(List<PlayerDAO> scoreBoard)
    {
        StreamReader streamReader = new StreamReader(file);
        string line;
        while ((line = streamReader.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { separator }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int score = Convert.ToInt32(nameAndScore[1]);
            PlayerDAO playerData = new PlayerDAO(name, score);
            int position = scoreBoard.IndexOf(playerData);
            //OM spelaren inte redan finns på poängtavlan så läggs det till en ny,
            //ANNARS uppdateras det gamla resultatet.
            if (position < 0)
            {
                scoreBoard.Add(playerData);
            }
            else
            {
                scoreBoard[position].UpdatePosition(score);
            }
        }
        streamReader.Close();
                
    }
}
