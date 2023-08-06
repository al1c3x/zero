using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControllerScript : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Vector2 hotspot = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor , hotspot, CursorMode.ForceSoftware);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
