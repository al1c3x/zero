using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPool : MonoBehaviour
{
    protected string sTagToCompare = "Player";

    private ObjectPool<SlowPool> _objectPool;

    private MainPlayer mainPlayerReference = null;
    private GameManager GameManagerReference = null;
    
    private UI_StatusEffectHolderScript uiStatusEffect;

    void Start()
    {
        uiStatusEffect = FindObjectOfType<UI_StatusEffectHolderScript>();
    }

    public void AssignObjectPool(ObjectPool<SlowPool> objectPool)
    {
        _objectPool = objectPool;

        mainPlayerReference = FindObjectOfType<MainPlayer>();
    }

    public GameObject _bloodSplashPrefab;

    void OnTriggerEnter(Collider collision)
    {
        mainPlayerReference = FindObjectOfType<MainPlayer>();
        GameManagerReference = GameManager.instance;

        if (collision.transform.CompareTag(sTagToCompare))
        {
            //call speed buff fxn
            mainPlayerReference.MainPlayerAttributes.depletionMultiplier =
                GameManagerReference.GetSlowDepleteUpgradeEquivalent(GameManagerReference.GetUpgradeDictionary()[ECollectible.SlowDepleteCollectible]);
            // display effect icon in HUD
            uiStatusEffect.ActivateStatusEffectUI((int)ECollectible.SpeedCollectible);
            
            FindObjectOfType<CollectibleSpawner>()._slowPool.ReturnObject(this);
            Invoke("ResetAttribute", 5.0f);
            
        }
    }

    private void ResetAttribute()
    {
        mainPlayerReference.MainPlayerAttributes.depletionMultiplier = 0.01f;
    }
}
