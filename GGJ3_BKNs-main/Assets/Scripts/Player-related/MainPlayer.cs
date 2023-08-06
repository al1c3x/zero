using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MainPlayer : MonoBehaviour
{
    private List<IMPRefs> _componentList;

    // object's components
    [HideInInspector] public Transform CameraTransform;
    [HideInInspector] public MPAttribs MainPlayerAttributes;
    [HideInInspector] public MPLook MainPlayerLook;
    [HideInInspector] public MPSanity MainPlayerSanity;
    [HideInInspector] public PostProcessVolume CameraPostProcessVolume;
    [HideInInspector] public PlayerAnimController PlayerAnimController;
    [HideInInspector] public HealthDepletionBehavior HealthDepletionBehavior;

    private void Awake()
    {
        // gets the reference of the components
        CameraTransform = Camera.main.transform.parent;
        CameraPostProcessVolume = Camera.main.transform.GetComponent<PostProcessVolume>();
        if (GetComponentInChildren<MPLook>() != null) MainPlayerLook = GetComponentInChildren<MPLook>();
        else Debug.LogError("Missing 'MPLook' script!");
        if (GetComponentInChildren<MPSanity>() != null) MainPlayerSanity = GetComponentInChildren<MPSanity>();
        else Debug.LogError("Missing 'MPSanity' script!");
        if (GetComponentInChildren<PlayerAnimController>() != null) PlayerAnimController = GetComponentInChildren<PlayerAnimController>();
        else Debug.LogError("Missing 'PlayerAnimController' script!");
        if (GetComponentInChildren<HealthDepletionBehavior>() != null) HealthDepletionBehavior = GetComponentInChildren<HealthDepletionBehavior>();
        else Debug.LogError("Missing 'HealthDepletionBehavior' script!");

        // add it to the component list
        _componentList = new List<IMPRefs>();
        _componentList.Add(MainPlayerLook);
        _componentList.Add(MainPlayerSanity);
        _componentList.Add(PlayerAnimController);
        _componentList.Add(HealthDepletionBehavior);
    }

    private void Start()
    {
        // controls the start of all components
        foreach (var comp in _componentList)
        {
            comp.RefStart(this);
        }
    }

    private void Update()
    {
        // controls the update of all components
        foreach (var comp in _componentList)
        {
            comp.RefUpdate(this);
        }
    }
}