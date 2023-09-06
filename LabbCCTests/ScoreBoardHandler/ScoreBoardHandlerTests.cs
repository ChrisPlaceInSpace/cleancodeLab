using LabbCCTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace LabbCC.Tests;

[TestClass()]
public class ScoreBoardHandlerTests
{
    IUI ui;
    MockFileHandler fileHandler;
    MockScoreBoard mockScoreBoard;
    string seperator { get; set; }
    public ScoreBoardHandlerTests()
    {
        ui = new ConsoleIO();
        fileHandler = new MockFileHandler("MockScoreBoardTest.txt");
        mockScoreBoard = new MockScoreBoard(fileHandler, ui);
        seperator = "#&#";
    }
    [TestMethod()]
    public void UpdateScoreBoardTest()
    {
        string userName = "qwerty";
        int numberOfGuesses = 1;
        List<PlayerDAO> players = new List<PlayerDAO>();
        fileHandler.WriteToFile(userName, numberOfGuesses);
        mockScoreBoard.UpdateScoreBoard(players);
        string listAfterRunMethod = players[0].PlayerName + seperator + players[0].NumberOfGuesses.ToString();
        Assert.AreEqual(userName + seperator+numberOfGuesses.ToString().Trim(), listAfterRunMethod.Trim());
        File.Delete(fileHandler.File);
    }
    [TestMethod()]
    public void TruncateTest()
    {
        string name = "Berserkers";
        string expectedNameAfterTruncate = "Berserker";
        Assert.AreEqual(expectedNameAfterTruncate, mockScoreBoard.Truncate(name));
    }
    [TestMethod()]
    public void UpdatePositionTest()
    {
        PlayerDAO player = new PlayerDAO("JohnDoe", 1);
        int guess = 1;
        mockScoreBoard.UpdatePosition(player, guess);
        int guessesExpected = 2, gamesPlayedExpected = 2;
        Assert.AreEqual((guessesExpected, player.NumberOfGuesses),(gamesPlayedExpected, player.GamesPlayed));
    }
    [TestMethod()]
    public void CalculateAverageTest()
    {
        PlayerDAO player = new PlayerDAO("Jens", 5);
        Assert.AreEqual(5, mockScoreBoard.CalculateAverage(player));
    }
    
    // IN PROGRESS!
    //[TestMethod()]
    //public void SortScoreBoardTest()
    //{
    //    List<PlayerDAO> players = new List<PlayerDAO>()
    //    {
    //        { new PlayerDAO("PersonA", 4, ui) },
    //        { new PlayerDAO("PersonB", 5, ui) },
    //    };
    //    Assert.AreEqual(,mockScoreBoard.SortScoreboard(players));
    //}
}