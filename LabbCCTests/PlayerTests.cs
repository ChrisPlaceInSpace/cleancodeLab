using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabbCC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabbCCTests;

namespace LabbCC.Tests
{
    [TestClass()]
    public class PlayerTests
    {

        MockPlayerDAO playerDAO = new MockPlayerDAO
        {
            GamesPlayed = 2,
            PlayerName = "John",
            NumberOfGuesses = 5
        };

        [TestMethod()]
        public void AverageTest()
        {
            Assert.AreEqual(2.5, playerDAO.Average());
        }
        
        [TestMethod()]
        public void UpdatePositionTest()
        {
            int guessToAdd = 1;
            int initialGuesses = 5;
            int initialGamesPlayed = 3;

            playerDAO.UpdatePosition(guessToAdd);
            Assert.AreEqual(initialGuesses + guessToAdd, playerDAO.NumberOfGuesses);
            Assert.AreEqual(initialGamesPlayed + 1, playerDAO.GamesPlayed);
        }
    }
}