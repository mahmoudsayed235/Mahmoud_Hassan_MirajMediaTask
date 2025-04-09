using UnityEngine;

public class AppStateManager : MonoBehaviour
{
    public static AppStateManager Instance { get; private set; }

    private IAppState currentState;

    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    void Start()
    {
        SetState(new IdleState());
    }

    public void SetState(IAppState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
