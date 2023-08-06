using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_SpecialSkill : MonoBehaviour, IMPRefs
{
    private MainPlayer _mainRef;

    public void RefStart(MainPlayer mainRef)
    {
        _mainRef = mainRef;
    }

    public void RefUpdate(MainPlayer mainRef)
    {

    }

    public void FireSpecialSkill()
    {
        _mainRef.PlayerAnimController._animator.SetFloat("SpeedMultiplier", 2.0f);
    }
}
