namespace LabbCC.Interfaces
{
    public interface IFilehandler
    {

        public string File { get; set;  }
        public string Separator { get; set; }
        List<string> Read();
        void WriteToFile(string userName, int numberOfGuesses);
    }
}