using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public string clipName;
    private bool playOnce = true;

    private void Update()
    {
        if (playOnce)
        {
            tAudioManager.instance.playBGMByName(clipName);
            playOnce = false;
        }
    }
}
