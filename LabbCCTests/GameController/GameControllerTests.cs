using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabbCC;

namespace LabbCCTests;

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

