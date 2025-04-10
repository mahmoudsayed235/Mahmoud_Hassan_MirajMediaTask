using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] 
    private string videoName;
    public void OnClick()
    {
        AppStateManager.Instance.SetState(new PlaybackState(videoName));
    }
}
