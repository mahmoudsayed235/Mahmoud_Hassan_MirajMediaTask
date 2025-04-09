public class PlaybackState : IAppState
{
    private string videoName;

    public PlaybackState(string videoName)
    {
        this.videoName = videoName;
    }

    public void Enter()
    {
        VideoManager.Instance.PlayVideo(videoName, loop: false, onComplete: () =>
        {
            AppStateManager.Instance.SetState(new IdleState());
        });
    }

    public void Exit()
    {

    }
}
