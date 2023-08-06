using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimation : MonoBehaviour, IHumanAnimation<HumanAnimController>
{
    public void RunningAnim(HumanAnimController con)
    {
        con.CurrentState = HumanStates.WALKING;
    }

    public void DeathAnim(HumanAnimController con)
    {
        con.CurrentState = HumanStates.DEATH;
    }
}
