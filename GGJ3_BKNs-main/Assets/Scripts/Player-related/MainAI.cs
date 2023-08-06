using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MainAI : MonoBehaviour
{
    private List<IHumanRefs> _componentList;

    // object's components
    [HideInInspector] public HumanAnimController HumanAnimController;

    private void Awake()
    {
        // gets the reference of the components
        if (GetComponentInChildren<HumanAnimController>() != null) HumanAnimController = GetComponentInChildren<HumanAnimController>();
        else Debug.LogError("Missing 'PlayerAnimController' script!");

        // add it to the component list
        _componentList = new List<IHumanRefs>();
        _componentList.Add(HumanAnimController);
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