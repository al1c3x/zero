using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeinFade : MonoBehaviour
{
    private Image image;
    [SerializeField] private bool asset;

    private bool fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        if(asset == true)
        {
            image.CrossFadeColor(Color.black, 0f, true, true);
            image.CrossFadeColor(Color.white, 5f, true, true);
        }
        else
        {
            image.CrossFadeColor(Color.black, 0f, true, true);
            image.CrossFadeColor(Color.white, 5f, true, true);
        }

    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
