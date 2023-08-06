using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    private GameManager gm;
    private int init_Speed;
    private int init_Multiplier;
    private int init_SlowDeplete;

    [SerializeField] private Image[] UpgradeArray1;
    [SerializeField] private Image[] UpgradeArray2;
    [SerializeField] private Image[] UpgradeArray3;

    [SerializeField] private TextMeshProUGUI[] priceText;
    [SerializeField] private TextMeshProUGUI currencyText;
    private int currentPrice1;
    private int currentPrice2;
    private int currentPrice3;

    private void Awake()
    {
        gm = GameManager.instance;
        currentPrice1 = 5;
        currentPrice2 = 5;
        currentPrice3 = 5;
    }

    private void OnEnable()
    {
        init_Speed = gm.GetUpgradeDictionary()[ECollectible.SpeedCollectible];
        init_Multiplier = gm.GetUpgradeDictionary()[ECollectible.MultiplierCollectible];
        init_SlowDeplete = gm.GetUpgradeDictionary()[ECollectible.SlowDepleteCollectible];

        Debug.Log(init_Speed);
        Debug.Log(init_Multiplier);
        Debug.Log(init_SlowDeplete);

        UpdateUpgradeData();
    }

    private void UpdateUpgradeData()
    {
        for (var i = 0; i < init_Speed; i++)
        {
            UpgradeArray1[i].color = new Color32(1, 197, 0, 255);
        }
        for (var i = 0; i < init_Multiplier; i++)
        {
            UpgradeArray2[i].color = new Color32(100, 119, 198, 255);
        }
        for (var i = 0; i < init_SlowDeplete; i++)
        {
            UpgradeArray3[i].color = new Color32(198, 4, 0, 255);
        }

 
        priceText[0].text = "Price: " + currentPrice1.ToString();
        priceText[1].text = "Price: " + currentPrice2.ToString();
        priceText[2].text = "Price: " + currentPrice3.ToString();
        currencyText.text = "Currency: " + CurrencyManager.Instance.GetCurrency();

    }

    public void SetUpgradeValue(int index)
    {
        switch (index)
        {
            case 0:
                if (CurrencyManager.Instance.GetCurrency() >= currentPrice1)
                {
                    gm.GetUpgradeDictionary()[ECollectible.SpeedCollectible] += 1;
                    CurrencyManager.Instance.SubtractCurrency(currentPrice1);
                    IncreasePrice(index);
                    DataPersistenceManager.instance.SaveGame();
                }
                else
                {
                    Debug.Log("Missing " + (currentPrice1 - CurrencyManager.Instance.GetCurrency()));
                }
                break;
            case 1:
                if (CurrencyManager.Instance.GetCurrency() >= currentPrice2)
                {
                    gm.GetUpgradeDictionary()[ECollectible.MultiplierCollectible] += 1;
                    CurrencyManager.Instance.SubtractCurrency(currentPrice2);
                    IncreasePrice(index);
                    DataPersistenceManager.instance.SaveGame();
                }
                else
                {
                    Debug.Log("Missing " + ( currentPrice2 - CurrencyManager.Instance.GetCurrency()));
                }
                break;
            case 2:
                if (CurrencyManager.Instance.GetCurrency() >= currentPrice3)
                {
                    gm.GetUpgradeDictionary()[ECollectible.SlowDepleteCollectible] += 1;
                    CurrencyManager.Instance.SubtractCurrency(currentPrice3);
                    IncreasePrice(index);
                    DataPersistenceManager.instance.SaveGame();
                }
                else
                {
                    Debug.Log("Missing " + (currentPrice3 - CurrencyManager.Instance.GetCurrency()));
                }
                break;
            default:
                break;
        }
                UpdateGameManagerData();

    }

    private void UpdateGameManagerData()
    {
        init_Speed = gm.GetUpgradeDictionary()[ECollectible.SpeedCollectible];
        init_Multiplier = gm.GetUpgradeDictionary()[ECollectible.MultiplierCollectible];
        init_SlowDeplete = gm.GetUpgradeDictionary()[ECollectible.SlowDepleteCollectible];

        UpdateUpgradeData();
    }

    private void IncreasePrice(int index)
    {
        switch (index)
        {
            case 0:
                currentPrice1 += currentPrice1 * 100;
                break;
            case 1:
                currentPrice2 += currentPrice2 * 100;
                break;
            case 2:
                currentPrice3 += currentPrice3 * 100;
                break;
        }
        
    }
}
