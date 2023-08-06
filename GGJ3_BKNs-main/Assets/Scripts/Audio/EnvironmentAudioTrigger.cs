using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnvironmentAudioTrigger : MonoBehaviour
{
    [HideInInspector]public SphereCollider _sphereCollider;
    [HideInInspector]public Rigidbody _rigidBody;

    public string clipName;
    public string exitClipName;
    public float radius = 5;

    private bool isAvailable = true;
    private float elapsedTime = 0.0f;
    
    void Awake()
    {
        _sphereCollider = this.AddComponent<SphereCollider>();
        _sphereCollider.isTrigger = true;
        _sphereCollider.radius = radius;

        _rigidBody = this.AddComponent<Rigidbody>();
        _rigidBody.useGravity = false;
        _rigidBody.isKinematic = true;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isAvailable)
        {
            Debug.LogWarning("Collided");
            tAudioManager.instance.playSFXByName(clipName, this.transform);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && isAvailable)
        {
            isAvailable = false;
            tAudioManager.instance.playSFXByName(exitClipName, this.transform);
        }
    }

    void Update()
    {
        /*
        if (!isAvailable)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= 20.0f)
            {
                elapsedTime = 0;
                isAvailable = true;
            }
        }
        */
    }
}
