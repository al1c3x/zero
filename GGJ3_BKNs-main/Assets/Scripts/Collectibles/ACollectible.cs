using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACollectible : MonoBehaviour
{
    public ECollectible collectibleType;
    public abstract void ApplyEffect();
}
