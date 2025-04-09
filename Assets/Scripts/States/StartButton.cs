using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {
        AppStateManager.Instance.SetState(new MenuState());
    }
}
