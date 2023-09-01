namespace LabbCC.Interfaces
{
    public interface IFilehandler   //Byta namn till DataHandler?
    {
        public string File { get; set;  }
        public string Separator { get; set; }
        List<string> ReadFile();
        void WriteToFile(string userName, int numberOfGuesses);
    }
}