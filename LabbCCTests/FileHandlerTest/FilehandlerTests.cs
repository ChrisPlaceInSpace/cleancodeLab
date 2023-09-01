using LabbCC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabbCCTests.FileHandlerTest
{
    [TestClass()]
    public class FilehandlerTests
    {
        
        
        [TestMethod()]
        public void FilehandlerTest()
        {
            
        }

        [TestMethod()]
        public void WriteToFileTest()
        {
            MockFileHandler fileHandler = new MockFileHandler("TestFile.txt", "#%#");
            string userName = "admin";
            int numberOfGuesses = 1;
            fileHandler.WriteToFile(userName, numberOfGuesses);
            Assert.IsTrue(File.Exists(fileHandler.File));
            string readText = File.ReadAllText(fileHandler.File);
            Assert.AreEqual("admin#%#1", readText);
            File.Delete(fileHandler.File);
        }

        [TestMethod()]
        public void ReadFileTest()
        {
            //List<string> lines = new List<string>();
            //Assert.AreEqual(lines, fileHandler.ReadFile());
        }
    }
}