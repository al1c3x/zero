using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultPool : MonoBehaviour
{
    protected string sTagToCompare = "Player";

    private ObjectPool<MultPool> _objectPool;

    private MainPlayer mainPlayerReference = null;
    private GameManager GameManagerReference = null;
    
    private UI_StatusEffectHolderScript uiStatusEffect;

    void Start()
    {
        uiStatusEffect = FindObjectOfType<UI_StatusEffectHolderScript>();
    }

    public void AssignObjectPool(ObjectPool<MultPool> objectPool)
    {
        _objectPool = objectPool;

        mainPlayerReference = FindObjectOfType<MainPlayer>();
    }

    public GameObject _bloodSplashPrefab;
    
    void OnTriggerEnter(Collider collision)
    {
        GameManagerReference = GameManager.instance;


        if (collision.transform.CompareTag(sTagToCompare))
        {
            //call speed buff fxn
            mainPlayerReference.MainPlayerAttributes.scoreMultiplier =
                GameManagerReference.GetMultiplierUpgradeEquivalent(GameManagerReference.GetUpgradeDictionary()[ECollectible.MultiplierCollectible]);
            // display effect icon in HUD
            uiStatusEffect.ActivateStatusEffectUI((int)ECollectible.SpeedCollectible);
            
            FindObjectOfType<CollectibleSpawner>()._multPool.ReturnObject(this);
            Invoke("ResetAttribute", 5.0f);
            
        }
    }

    private void ResetAttribute()
    {
        mainPlayerReference.MainPlayerAttributes.scoreMultiplier = 1.0f;
    }
}
