public class MenuState : IAppState
{
    public void Enter()
    {
        UIManager.Instance.ShowMenu();
    }

    public void Exit()
    {
        UIManager.Instance.HideMenu();
    }
}