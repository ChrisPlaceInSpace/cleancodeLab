namespace LabbCC
{
    public interface IGameController
    {
        bool Continue(bool gameOn);
        void Game(string userName);
        void RunGame();
    }
}