using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceController : MonoBehaviour
{
    public string clipName;
    private bool playOnce = true;

    private void Update()
    {
        if (playOnce)
        {
            tAudioManager.instance.playAmbienceByName(clipName);
            playOnce = false;
        }
    }
}
