using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour, IMPRefs
{
    // Property with set values for playing certain animation 
    public ZombieStates CurrentState
    {
        set
        {
            _currentState = value;

            switch (_currentState)
            {
                case ZombieStates.IDLE:
                    _animator.Play("Idle");
                    break;
                case ZombieStates.WALKING:
                    _animator.CrossFade("Walking", 1.0f);
                    //_animator.Play("Walking");
                    break;
                case ZombieStates.ATTACK:
                    _animator.CrossFade("Attack", 0.5f);
                    //_animator.Play("Attack");
                    break;
                case ZombieStates.FLEX:
                    _animator.Play("Flex");
                    break;
                case ZombieStates.DEATH:
                    _animator.Play("Death");
                    break;
                default:
                    Debug.LogWarning($"{name} doesn't contain a {value} animation!");
                    break;
            }
        }
        get { return _currentState; }
    }
    private ZombieStates _currentState;
    
    // Attributes


    // Components
    [HideInInspector] public Animator _animator;
    [HideInInspector] public PlayerAnimation _playerAnimation;
    
    public void RefStart(MainPlayer mainRef)
    {
        // Initialize components
        _animator = GetComponent<Animator>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void RefUpdate(MainPlayer mainRef)
    {

    }

    public void FireAttackAnim()
    {
        _playerAnimation.AttackAnim(this);
    }
    public void FireWalkAnim()
    {
        _playerAnimation.WalkAnim(this);
        Debug.LogError("Fire Walk");
    }
    
    public void FireDeathAnim()
    {
        _playerAnimation.DeathAnim(this);
    }
}
