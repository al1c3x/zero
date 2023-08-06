using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimController : MonoBehaviour, IHumanRefs
{// Property with set values for playing certain animation 
    public HumanStates CurrentState
    {
        set
        {
            _currentState = value;

            switch (_currentState)
            {
                case HumanStates.WALKING:
                    _animator.Play("Walking");
                    break;
                case HumanStates.DEATH:
                    _animator.CrossFade("Death", 1.0f);
                    //_animator.Play("Walking");
                    break;
                default:
                    Debug.LogWarning($"{name} doesn't contain a {value} animation!");
                    break;
            }
        }
        get { return _currentState; }
    }
    private HumanStates _currentState;
    
    // Attributes


    // Components
    [HideInInspector] public Animator _animator;
    [HideInInspector] public HumanAnimation _humanAnimation;
    
    public void RefStart(MainAI mainRef)
    {
        // Initialize components
        _animator = GetComponent<Animator>();
        _humanAnimation = GetComponent<HumanAnimation>();
    }

    public void RefUpdate(MainAI mainRef)
    {

    }
}
