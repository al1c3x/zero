using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour, IZombieAnimation<PlayerAnimController>
{
    public void IdleAnim(PlayerAnimController con)
    {
        con.CurrentState = ZombieStates.IDLE;
        //con._animator.SetFloat("xMove", con._moveInput.x, 0.05f, Time.deltaTime);
        //con._animator.SetFloat("yMove", con._moveInput.y, 0.05f, Time.deltaTime);
    }

    public void WalkAnim(PlayerAnimController con)
    {
        con.CurrentState = ZombieStates.WALKING;
        //con._animator.SetFloat("xMove", con._moveInput.x, 0.05f, Time.deltaTime);
        //con._animator.SetFloat("yMove", con._moveInput.y, 0.05f, Time.deltaTime);
    }
    public void AttackAnim(PlayerAnimController con)
    {
        con.CurrentState = ZombieStates.ATTACK;
        //con._animator.SetFloat("xMove", con._moveInput.x, 0.05f, Time.deltaTime);
        //con._animator.SetFloat("yMove", con._moveInput.y, 0.05f, Time.deltaTime);
    }
    public void FlexAnim(PlayerAnimController con)
    {
        con.CurrentState = ZombieStates.FLEX;
        //con._animator.SetFloat("xMove", con._moveInput.x, 0.05f, Time.deltaTime);
        //con._animator.SetFloat("yMove", con._moveInput.y, 0.05f, Time.deltaTime);
    }
    public void DeathAnim(PlayerAnimController con)
    {
        con.CurrentState = ZombieStates.DEATH;
        //con._animator.SetFloat("xMove", con._moveInput.x, 0.05f, Time.deltaTime);
        //con._animator.SetFloat("yMove", con._moveInput.y, 0.05f, Time.deltaTime);
    }
}
