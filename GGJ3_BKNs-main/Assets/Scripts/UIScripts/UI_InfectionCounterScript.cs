using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_InfectionCounterScript : MonoBehaviour
{
    private TextMeshProUGUI infectionNumber;

    void Awake()
    {
        infectionNumber = transform.Find("Text_InfectionNumber").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateInfectionCountUI(int infectionCount)
    {
        infectionNumber.text = infectionCount.ToString();
    }
}
