using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChunk : MonoBehaviour
{
    protected string sTagToCompare = "Player";

    private ObjectPool<ZombieChunk> _objectPool;

  
    public void AssignObjectPool(ObjectPool<ZombieChunk> objectPool)
    {
        _objectPool = objectPool;

       
    }
}
