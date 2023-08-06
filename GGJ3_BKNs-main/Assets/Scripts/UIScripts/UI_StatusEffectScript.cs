using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatusEffectScript : MonoBehaviour
{
    private Image radialFill;

    void Awake()
    {
        radialFill = transform.Find("RadialBar").GetComponent<Image>();
    }

    public void UpdateStatusEffectUI(float normalizedTimer)
    {
        radialFill.fillAmount = normalizedTimer;
    }
}
