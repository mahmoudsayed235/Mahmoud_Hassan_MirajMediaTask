
public class IdleState : IAppState
{
    public void Enter()
    {
        VideoManager.Instance.PlayVideo("idle.mp4", loop: true);
    }

    public void Exit()
    {
        UIManager.Instance.HideStartScreen();
    }
}
