using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject startPanel, menuPanel;

    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    public void ShowStartScreen()
    {
        startPanel.SetActive(true);
    }
    public void HideStartScreen()
    {
        startPanel.SetActive(false);
    }
    public void ShowMenu()
    {
        menuPanel.SetActive(true);
    }
    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }
}
