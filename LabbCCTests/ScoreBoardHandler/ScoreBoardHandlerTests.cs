using LabbCCTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabbCC.Tests;

[TestClass()]
public class ScoreBoardHandlerTests
{
    IUI ui;
    const string seperator = "#&#";
    MockFileHandler fileHandler = new MockFileHandler("MockScoreBoardTest.txt", seperator);
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
        string listAfterRunMethod = players[0].PlayerName + seperator + players[0].NumberOfGuesses.ToString();
        Assert.AreEqual(userName+ seperator+numberOfGuesses.ToString().Trim(), listAfterRunMethod.Trim());
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