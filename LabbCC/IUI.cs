using System.Xml.Serialization;

namespace LabbCC;

public interface IUI
{
    void Output(string s);
    string Input();
    void ExitGame();
    void Clear();
}
