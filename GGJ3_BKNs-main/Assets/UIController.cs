using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] gamePanels;

    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject titleMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && titleScreen.activeSelf)
        {
            titleScreen.SetActive(false);
            titleMenu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var panel in gamePanels)
            {
                if (panel.activeSelf)
                    panel.SetActive(false);
            }
        }
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

}
