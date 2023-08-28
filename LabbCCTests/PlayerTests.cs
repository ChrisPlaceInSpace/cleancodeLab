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
                

        [TestMethod()]
        public void AverageTest()
        {
            MockPlayerDAO playerDAO = new MockPlayerDAO
            {
                GamesPlayed = 2,
                PlayerName = "John",
                NumberOfGuesses = 5
            };           

            Assert.AreEqual(2.5, playerDAO.Average());
        }
    }
}