using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabbCC.MooGame;
using LabbCC.Interfaces;
using LabbCC;
using System.Diagnostics;

namespace LabbCCTests
{
    [TestClass]
    public class GameControllerTests
    {

        [TestMethod]
        public void CanUserSelectGame()
        {
            IUI ui = new MockUI();
            GameController gameController = new GameController(ui);
          int actualOption = gameController.SelectedGameByUser();
            int expectedOption = 1;

            Assert.AreEqual(expectedOption, actualOption);
        }
    }

    public class MockUI : IUI
    {
        private int _outputCounter;
        public MockUI() {
            _outputCounter = 0;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void ExitGame()
        {
            throw new NotImplementedException();
        }

        public string Input()
        {
            _outputCounter++;
            switch (_outputCounter)
            {
                case 1:
                    return "1";
                case 2:
                    return "HEJ";
                default:
                    return "";
            }
           
        }

        public void Output(string s)
        {
            Debug.WriteLine($"'MockUI outputs: {s}");
        }
    }
}
