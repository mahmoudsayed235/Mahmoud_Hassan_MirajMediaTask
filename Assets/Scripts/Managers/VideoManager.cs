using UnityEngine;
using System.Collections;
using UnityEngine.Video;
using System.IO;
using System;
using TMPro;
public class VideoManager : MonoBehaviour
{
    public static VideoManager Instance { get; private set; }
    public VideoPlayer videoPlayer;
    private Action onVideoComplete;
    private string currentFileName="";
    private Coroutine prepareCoroutine;
    [SerializeField]
    private float prepareTimeout = 0.5f;
    [SerializeField]
    private TextMeshProUGUI title;

    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    public void PlayVideo(string fileName, bool loop, Action onComplete = null)
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);

        if (!File.Exists(path))
        {
            onComplete?.Invoke();
            Debug.LogError($"Video not found: {fileName}");
            return;
        }
        if (currentFileName.Equals(fileName))
        {
            return;
        }
        currentFileName = fileName;
        
        // Clean up any previous listeners
        videoPlayer.loopPointReached -= OnVideoEnd;

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = path;
        videoPlayer.isLooping = loop;
        onVideoComplete = onComplete;

        if (!loop && onComplete != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        videoPlayer.Prepare();

        if (prepareCoroutine != null)
        {
            StopCoroutine(prepareCoroutine);
        }
        prepareCoroutine = StartCoroutine(WaitForPrepareOrTimeout(path));
    }
    private IEnumerator WaitForPrepareOrTimeout(string path)
    {
        float timer = 0f;
        while (!videoPlayer.isPrepared && timer < prepareTimeout)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        if (!videoPlayer.isPrepared)
        {
            ToastManager.Instance.ShowToast("Timeout or unsupported format");
            Debug.LogError($"[SafeVideoPlayer] Timeout or unsupported format: {path}");
            onVideoComplete?.Invoke();
            yield break;
        }

        videoPlayer.Play();
        if (currentFileName.Equals("idle.mp4"))
        {
            title.text = "Mirage Media Task";
        }
        else
        {
            title.text = currentFileName.Substring(0, currentFileName.IndexOf("."));
        }
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        videoPlayer.loopPointReached -= OnVideoEnd; // Clean up
        onVideoComplete?.Invoke();
    }
    private void OnVideoError(VideoPlayer vp, string message)
    {
        Debug.LogError($"[VideoPlayer] Error playing video: {message}");
        onVideoComplete?.Invoke(); // fallback to trigger completion even on error
    }
}

