using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBlood : MonoBehaviour
{
    protected string sTagToCompare = "Player";

    private ObjectPool<HumanBlood> _objectPool;

   

    public void AssignObjectPool(ObjectPool<HumanBlood> objectPool)
    {
        _objectPool = objectPool;

        
    }

   

   
   
}
