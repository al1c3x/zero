using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPool : MonoBehaviour
{
    protected string sTagToCompare = "Player";

    private ObjectPool<SpeedPool> _objectPool;

    private MainPlayer mainPlayerReference = null;
    private GameManager GameManagerReference = null;

    private UI_StatusEffectHolderScript uiStatusEffect;

    void Start()
    {
        uiStatusEffect = FindObjectOfType<UI_StatusEffectHolderScript>();
    }

    public void AssignObjectPool(ObjectPool<SpeedPool> objectPool)
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
            mainPlayerReference.MainPlayerAttributes.playerSpeed =
                GameManagerReference.GetSpeedUpgradeEquivalent(GameManagerReference.GetUpgradeDictionary()[ECollectible.SpeedCollectible]);

            mainPlayerReference.GetComponent<PlayerAnimController>()._animator.SetFloat("SpeedMultiplier", mainPlayerReference.MainPlayerAttributes.playerSpeed);

            // display effect icon in HUD
            uiStatusEffect.ActivateStatusEffectUI((int)ECollectible.SpeedCollectible);
            
            FindObjectOfType<CollectibleSpawner>()._speedPool.ReturnObject(this);
            Invoke("ResetAttribute", 5.0f);
            
        }
    }

    private void ResetAttribute()
    {
        mainPlayerReference.MainPlayerAttributes.playerSpeed = 1.5f;
        mainPlayerReference.GetComponent<PlayerAnimController>()._animator.SetFloat("SpeedMultiplier", 1);
    }
}
