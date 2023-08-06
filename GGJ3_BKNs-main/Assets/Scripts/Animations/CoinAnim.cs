using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnim : MonoBehaviour
{
    private float ticks = 0.0f;
    void Update()
    {

        Vector3 NewLocation = transform.position;
        ticks += Time.deltaTime;
        float DeltaHeight = (Mathf.Sin(ticks + Time.deltaTime) - Mathf.Sin(ticks));
        NewLocation.y += DeltaHeight * 0.02f;       //Scale our height by a factor of 20
        transform.Rotate(0.0f, Time.deltaTime * 20.0f, 0.0f, Space.World);
        // transform.RotateAround(transform.position, transform.up, Time.deltaTime * 20f);
        transform.position = NewLocation;
    }
}
