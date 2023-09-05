using LabbCC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabbCCTests;

[TestClass()]
public class MooGameLogicTests
{
    IUI ui = new ConsoleIO();
    [TestMethod()]
    public void PlayLogicTest()
    {
        int numberOfGuesses = 0;
        MockMooGameLogic mooGameLogic = new MockMooGameLogic(ui);
        Assert.AreEqual(1, mooGameLogic.PlayLogic());
    }
    [TestMethod()]
    public void GoalGeneratorTest()
    {
        MockMooGameLogic mooGameLogic = new MockMooGameLogic(ui);
        string goal = "0000";
        Assert.AreEqual(goal.Length, mooGameLogic.GoalGenerator().Length);
    }
    [TestMethod()]
    public void ResultFromGuessTest()
    {
        MockMooGameLogic mooGameLogic = new MockMooGameLogic(ui);
        string goal = "0000";
        string guess = "0111";
        string expectedResult = "BCCC";
        Assert.AreEqual(expectedResult, mooGameLogic.ResultFromGuess(goal, guess));
    }
    [TestMethod()]
    public void CountHitTest()
    {
        MockMooGameLogic mooGameLogic = new MockMooGameLogic(ui);
        string goal = "0000";
        string guess = "0111";
        Assert.AreEqual(1, mooGameLogic.CountHit(goal, guess));
    }
    [TestMethod()]
    public void CountMissTest()
    {
        string goal = "1234";
        string guess = "4321";
        MockMooGameLogic mooGameLogic = new MockMooGameLogic(ui);
        Assert.AreEqual(4, mooGameLogic.CountMiss(goal, guess));
    }
}