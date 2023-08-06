using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDepletionBehavior : MonoBehaviour, IMPRefs
{
    private UI_HealthScript healthSc;
    public void RefStart(MainPlayer mainRef)
    {
        healthSc = FindObjectOfType<UI_HealthScript>();
    }

    public void RefUpdate(MainPlayer mainRef)
    {
        if (mainRef.MainPlayerAttributes.playerHealth > 0)
        {
            mainRef.MainPlayerAttributes.playerHealth -= (1 * mainRef.MainPlayerAttributes.depletionMultiplier);
            healthSc.UpdateHealthUI(mainRef.MainPlayerAttributes.playerHealth / 100.0f);
        }
        else
        {
            mainRef.PlayerAnimController.FireDeathAnim();
            FindObjectOfType<tLoader>().LoadScene(0);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 

            DataPersistenceManager.instance.SaveGame();
        }
    }
}
