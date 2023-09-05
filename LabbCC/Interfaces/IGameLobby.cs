namespace LabbCC;

public interface IGameLobby
{
    void GameMenu();
    int PrintMenuOptions();
    void OptionSelector(int select);
    void SelectedGame(int select);
}