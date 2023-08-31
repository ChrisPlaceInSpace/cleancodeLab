using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabbCCTests.MooGame;

namespace LabbCC.MooGame.Tests
{
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
        public void BullAndCowStringBuilderTest()
        {
            MockMooGameLogic mooGameLogic = new MockMooGameLogic();
            string goal = "0000";
            string guess = "0111";
            string expectedResult = "BCCC";
            Assert.AreEqual(expectedResult, mooGameLogic.BullAndCowStringBuilder(goal, guess));
        }

        [TestMethod()]
        public void CountBullTest()
        {
            MockMooGameLogic mooGameLogic = new MockMooGameLogic();
            string goal = "0000";
            string guess = "0111";
            Assert.AreEqual(1, mooGameLogic.CountBull(goal, guess));
        }

        [TestMethod()]
        public void CountCowTest()
        {
            string goal = "1234";
            string guess = "4321";
            MockMooGameLogic mooGameLogic = new MockMooGameLogic();
            Assert.AreEqual(4, mooGameLogic.CountCow(goal, guess));
        }
    }
}