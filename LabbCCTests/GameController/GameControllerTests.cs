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
        GameLobby gameLobby = new GameLobby(ui);
        int actualOption = gameLobby.PrintMenuOptions();
        int expectedOption = 1;
        Assert.AreEqual(expectedOption, actualOption);
    }
}

