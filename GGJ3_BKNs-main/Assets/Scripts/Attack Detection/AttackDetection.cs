using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    private UI_InfectionCounterScript uiInfectionCounter;
    private MainPlayer mpSc;
    private GameManager gm;

    private HumanAnimController humanAnim;

    private HumanPool humanPool;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        uiInfectionCounter = FindObjectOfType<UI_InfectionCounterScript>();
        mpSc = FindObjectOfType<MainPlayer>();
        humanAnim = GetComponent<HumanAnimController>();
        if (GetComponent<HumanPool>())
            humanPool = GetComponent<HumanPool>(); else Debug.LogError("Human Pool not found");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log(mpSc.PlayerAnimController.CurrentState);
            //check if attack button is clicked
            if(mpSc.PlayerAnimController.CurrentState == ZombieStates.ATTACK)
            {
                // update score
                gm.SetPlayerScore(gm.GetPlayerScore() + 1);
                uiInfectionCounter.UpdateInfectionCountUI(gm.GetPlayerScore());
                //kill NPC by returning to pool
                humanAnim._humanAnimation.DeathAnim(humanAnim);
                // Increment money
                CurrencyManager.Instance.AddCurrency(1);
                Invoke("ReturnHumanPool", 5.0f);
                Debug.LogWarning("KILL");

                //regen health
                if(mpSc.MainPlayerAttributes.playerHealth < 100)
                    mpSc.MainPlayerAttributes.playerHealth += 0.1f;

                //play kill sfx?
            }

        }
    }

    void ReturnHumanPool()
    {
        FindObjectOfType<HumanSpawner>()._objectPool.ReturnObject(humanPool);
    }
}
