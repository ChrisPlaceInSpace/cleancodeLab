using LabbCC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabbCCTests;

[TestClass()]
public class FilehandlerTests
{
    [TestMethod()]
    public void FileHandlingTest()
    {
        MockFileHandler fileHandler = new MockFileHandler("TestFile.txt");
        string userName = "admin";
        int numberOfGuesses = 1;
        fileHandler.WriteToFile(userName, numberOfGuesses);
        Assert.IsTrue(File.Exists(fileHandler.File));
        List<string> readText = new List<string>(fileHandler.ReadFile());
        string actualText = readText[0];
        Assert.AreEqual(userName + fileHandler.TextSeparator + numberOfGuesses.ToString().Trim(), actualText.Trim());
        File.Delete(fileHandler.File);
    }
}