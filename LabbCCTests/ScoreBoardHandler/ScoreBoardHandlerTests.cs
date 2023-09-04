using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabbCC;
using LabbCCTests;
using System.Xml.Linq;

namespace LabbCC.Tests;

[TestClass()]
public class ScoreBoardHandlerTests
{
    IUI ui;
    MockFileHandler fileHandler = new MockFileHandler("MockScoreBoardTest.txt", "#&#");
    MockScoreBoardHandler mockScoreBoardHandler;

    [TestMethod()]
    public void UpdateScoreBoardTest()
    {
        mockScoreBoardHandler = new MockScoreBoardHandler(fileHandler, ui);
        string userName = "qwerty";
        int numberOfGuesses = 1;

        List<PlayerDAO> players = new List<PlayerDAO>();
        fileHandler.WriteToFile(userName, numberOfGuesses);
        mockScoreBoardHandler.UpdateScoreBoard(players);
        string listAfterRunMethod = players[0].PlayerName + "#&#" + players[0].NumberOfGuesses.ToString();
        Assert.AreEqual("qwerty#&#1".Trim(), listAfterRunMethod.Trim());
        File.Delete(fileHandler.File);
    }

    [TestMethod()]
    public void TruncateTest()
    {
        mockScoreBoardHandler = new MockScoreBoardHandler(fileHandler, ui);
        string name = "Berserkers";
        string expectedNameAfterTruncate = "Berserker";
        Assert.AreEqual(expectedNameAfterTruncate, mockScoreBoardHandler.Truncate(name));
    }

    [TestMethod()]
    public void UpdatePositionTest()
    {
        mockScoreBoardHandler = new MockScoreBoardHandler(fileHandler, ui);
        PlayerDAO player = new PlayerDAO("JohnDoe", 1, ui);
        int guess = 1;
        mockScoreBoardHandler.UpdatePosition(player, guess);
        int guessesExpected = 2, gamesPlayedExpected = 2;
        Assert.AreEqual((guessesExpected, player.NumberOfGuesses),(gamesPlayedExpected, player.GamesPlayed));
    }

    [TestMethod()]
    public void CalculateAverageTest()
    {
        mockScoreBoardHandler = new MockScoreBoardHandler(fileHandler, ui);
        PlayerDAO player = new PlayerDAO("Jens", 5, ui);
        Assert.AreEqual(5, mockScoreBoardHandler.CalculateAverage(player));
    }
}