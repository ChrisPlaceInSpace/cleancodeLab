using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabbCC;

namespace LabbCCTests;

[TestClass()]
public class MooGameLogicTests
{

    [TestMethod()]
    public void PlayLogicTest()
    {
        int numberOfGuesses = 0;
        MockMooGameLogic mooGameLogic = new MockMooGameLogic();
        Assert.AreEqual(1, mooGameLogic.PlayLogic(numberOfGuesses));
    }

    [TestMethod()]
    public void GoalGeneratorTest()
    {
        MockMooGameLogic mooGameLogic = new MockMooGameLogic();
        string goal = "0000";
        Assert.AreEqual(goal.Length, mooGameLogic.GoalGenerator().Length);
    }

    [TestMethod()]
    public void GameStringBuilderTest()
    {
        MockMooGameLogic mooGameLogic = new MockMooGameLogic();
        string goal = "0000";
        string guess = "0111";
        string expectedResult = "BCCC";
        Assert.AreEqual(expectedResult, mooGameLogic.GameStringBuilder(goal, guess));
    }

    [TestMethod()]
    public void CountHitTest()
    {
        MockMooGameLogic mooGameLogic = new MockMooGameLogic();
        string goal = "0000";
        string guess = "0111";
        Assert.AreEqual(1, mooGameLogic.CountHit(goal, guess));
    }

    [TestMethod()]
    public void CountMissTest()
    {
        string goal = "1234";
        string guess = "4321";
        MockMooGameLogic mooGameLogic = new MockMooGameLogic();
        Assert.AreEqual(4, mooGameLogic.CountMiss(goal, guess));
    }
}