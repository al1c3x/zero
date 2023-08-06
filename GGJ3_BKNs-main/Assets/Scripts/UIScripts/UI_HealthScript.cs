using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthScript : MonoBehaviour
{
    private Transform healthBar;

    void Awake()
    {
        healthBar = transform.Find("bar").transform;
    }

    public void UpdateHealthUI(float normalizedHealth)
    {
        healthBar.transform.localScale = new Vector3(normalizedHealth, 1, 1);
    }

}
