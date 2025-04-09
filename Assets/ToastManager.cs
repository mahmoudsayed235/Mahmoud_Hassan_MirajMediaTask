using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ToastManager : MonoBehaviour
{
    public static ToastManager Instance;

    [Header("Toast UI References")]
    public GameObject toastPanel;
    public TextMeshProUGUI messageText;

    private Coroutine currentToast;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
        toastPanel.SetActive(false);
    }

    public void ShowToast(string message, float duration = 1f)
    {
        if (currentToast != null)
            StopCoroutine(currentToast);

        currentToast = StartCoroutine(ShowToastRoutine(message, duration));
    }

    private IEnumerator ShowToastRoutine(string message, float duration)
    {
        toastPanel.SetActive(true);
        messageText.text = message;

        yield return new WaitForSeconds(duration);

        toastPanel.SetActive(false);
        currentToast = null;
    }
}
