using UnityEngine;
using UnityEngine.Pool;

public class HumanPool : MonoBehaviour
{
    [HideInInspector]public ObjectPool<HumanPool> _objectPool;

    public void AssignObjectPool(ObjectPool<HumanPool> objectPool)
    {
        _objectPool = objectPool;
    }

    public GameObject _bloodSplashPrefab;

    /*
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = collision.transform.rotation;
        Vector3 position = contact.point;
        Instantiate(_bloodSplashPrefab, position, rotation);

        _objectPool.ReturnObject(this);
    }
    */
}
