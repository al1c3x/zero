using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class MPSanity : MonoBehaviour, IMPRefs
{
    [Tooltip("The weight of the post processing volume when the player is at max health")]
    public float InitialPostProcessVolumeWeight = 0.25f;

    [Tooltip("The weight of the post processing volume when the player is at zero health")]
    public float MaxPostProcessVolumeWeight = 1.0f;

    [Tooltip("Acceleration speed of the post proecss volume weight change")]
    public float Acceleration = 0.75f;

    private float InitialPlayerHealth;
    private float InitialMaxPostProcessVolumeWeightDifference;

    public void RefStart(MainPlayer mainRef)
    {
        InitialPlayerHealth = mainRef.MainPlayerAttributes.playerHealth;

        mainRef.CameraPostProcessVolume.weight = InitialPostProcessVolumeWeight;
        InitialMaxPostProcessVolumeWeightDifference = MaxPostProcessVolumeWeight - InitialPostProcessVolumeWeight;
    }

    public void RefUpdate(MainPlayer mainRef)
    {
        float healthRatio = 1.0f - (mainRef.MainPlayerAttributes.playerHealth / InitialPlayerHealth);
        float newCameraPostProcessVolumeWeight = Mathf.Clamp(InitialPostProcessVolumeWeight + (InitialMaxPostProcessVolumeWeightDifference * healthRatio), 0.0f, 1.0f);
        mainRef.CameraPostProcessVolume.weight = Mathf.Lerp(mainRef.CameraPostProcessVolume.weight, newCameraPostProcessVolumeWeight, Acceleration * Time.deltaTime);
    }
}
