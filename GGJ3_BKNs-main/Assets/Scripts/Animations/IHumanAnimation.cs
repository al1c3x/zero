using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HumanStates
{
    WALKING,
    DEATH
}

//public interface tIHumanAnimation<T>
public interface IHumanAnimation<T>
{
    //public void IH_MoveAnim(ref T param);
    public void RunningAnim(T con);
    public void DeathAnim(T con);
}