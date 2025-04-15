using UnityEngine;
using System.Collections;

public class ActivateAllDisplays : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f); // Give Unity a frame or two
        Debug.Log("displays connected: " + Display.displays.Length);

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }

    void Update()
    {

    }
}
