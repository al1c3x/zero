using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatusEffectHolderScript : MonoBehaviour
{
    [SerializeField] private Transform[] statusEffectGameObjects;
    private bool[] IsBuffEnable;
    private float[] buffTicks;
    private float buffDuration = 5.0f;

    void Start()
    {
        IsBuffEnable = new bool[3]{false, false, false};
        buffTicks = new float[3]{0.0f, 0.0f, 0.0f};
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < IsBuffEnable.Length; i++)
        {
            if (IsBuffEnable[i])
            {
                buffTicks[i] += Time.deltaTime;
                if (buffTicks[i] >= buffDuration)
                {
                    IsBuffEnable[i] = false;
                    ConfigureStatusEffect(i, 0);
                }
                else
                {
                    ConfigureStatusEffect(i, 1 - (buffTicks[i] / 5.0f));

                }
            }
        }
        foreach (var statusEffect in statusEffectGameObjects)
        {
            if (statusEffect.transform.Find("RadialBar").GetComponent<Image>().fillAmount <= 0)
                statusEffect.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateStatusEffectUI(1);
        }
    }

    public void ActivateStatusEffectUI(int statusEffectIndex)
    {
        statusEffectGameObjects[statusEffectIndex].gameObject.SetActive(true);
        IsBuffEnable[statusEffectIndex] = true;
    }
    public void ConfigureStatusEffect(int statusEffectIndex, float percentage)
    {
        statusEffectGameObjects[statusEffectIndex].transform.Find("RadialBar").GetComponent<Image>().fillAmount =
            percentage;
    }
}
