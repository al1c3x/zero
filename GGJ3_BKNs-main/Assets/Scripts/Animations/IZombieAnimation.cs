using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieStates
{
    WALKING,
    IDLE,
    ATTACK,
    FLEX,
    DEATH
}

//public interface tIHumanAnimation<T>
public interface IZombieAnimation<T>
{
    //public void IH_MoveAnim(ref T param);
    public void IdleAnim(T con);
    public void WalkAnim(T con);
}
