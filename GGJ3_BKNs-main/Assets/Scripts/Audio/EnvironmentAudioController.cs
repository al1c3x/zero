using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnvironmentAudioController : MonoBehaviour
{
    private IDictionary<string, string> environmentSFX = new Dictionary<string, string>();

    void Awake()
    {
        environmentSFX.Add("Bell", "Bell");
        environmentSFX.Add("SonicHit", "Sonic");
    }
}
