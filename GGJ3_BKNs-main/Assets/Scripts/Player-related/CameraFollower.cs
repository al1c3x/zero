using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private MainPlayer _mainPlayer;
    private Vector3 _mainPlayerDistance;

    // Start is called before the first frame update
    void Start()
    {
        _mainPlayer = FindObjectOfType<MainPlayer>();
        _mainPlayerDistance = transform.position - _mainPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _mainPlayer.transform.position + _mainPlayerDistance;
    }
}
