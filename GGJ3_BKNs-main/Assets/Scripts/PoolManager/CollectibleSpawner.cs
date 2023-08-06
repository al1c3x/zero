using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnLocation;
    [SerializeField] private Transform _sourceLocation;
    [SerializeField] private GameObject _speedPrefab;
    [SerializeField] private GameObject _multPrefab;
    [SerializeField] private GameObject _slowPrefab;

    public ObjectPool<SpeedPool> _speedPool;
    public ObjectPool<MultPool> _multPool;
    public ObjectPool<SlowPool> _slowPool;

    void Start()
    {
        
        
        if (_spawnLocation == null || _sourceLocation == null)
            Debug.LogError("Missing one or more Transform requirement!");
        // for speed pool
        if (_speedPrefab == null || _speedPrefab.GetComponent<SpeedPool>() == null)
            Debug.LogError("Missing prefab or component!");
        else
        {
            _speedPool = new ObjectPool<SpeedPool>(SpeedFactoryMethod, TurnOnSpeed, TurnOffSpeed, 5, true);
        }
        // for mult pool
        if (_multPrefab == null || _multPrefab.GetComponent<MultPool>() == null)
            Debug.LogError("Missing prefab or component!");
        else
        {
            _multPool = new ObjectPool<MultPool>(MultFactoryMethod, TurnOnMult, TurnOffMult, 5, true);
        }
        // for slow pool
        if (_slowPrefab == null || _slowPrefab.GetComponent<SlowPool>() == null)
            Debug.LogError("Missing prefab or component!");
        else
        {
            _slowPool = new ObjectPool<SlowPool>(SlowFactoryMethod, TurnOnSlow, TurnOffSlow, 5, true);
        }
    }

    // For speed pool
    private SpeedPool SpeedFactoryMethod()
    {
        GameObject obj = Instantiate(_speedPrefab) as GameObject;
        SpeedPool objScript = obj.GetComponent<SpeedPool>();
        // attach a reference of the objectPool to the pool object
        objScript.AssignObjectPool(_speedPool);

        obj.transform.parent = _sourceLocation;
        obj.gameObject.SetActive(false);

        return obj.GetComponent<SpeedPool>();
    }

    private void TurnOnSpeed(SpeedPool speed)
    {
        int rand = Random.Range(0, _spawnLocation.Count - 1);
        // parent and reposition(displayed) the recently borrowed pool object
        speed.transform.parent = _spawnLocation[rand];
        speed.transform.position = _spawnLocation[rand].position;

        speed.gameObject.SetActive(true);
    }
    private void TurnOffSpeed(SpeedPool speed)
    {
        // parent and reposition(hidden) the recently borrowed pool object
        speed.transform.parent = _sourceLocation;
        speed.transform.position = _sourceLocation.position;

        speed.gameObject.SetActive(false);
        Debug.Log($"Return Speed");
    }
    
    // For Mult pool
    private MultPool MultFactoryMethod()
    {
        GameObject obj = Instantiate(_multPrefab) as GameObject;
        MultPool objScript = obj.GetComponent<MultPool>();
        // attach a reference of the objectPool to the pool object
        objScript.AssignObjectPool(_multPool);

        obj.transform.parent = _sourceLocation;
        obj.gameObject.SetActive(false);

        return obj.GetComponent<MultPool>();
    }

    private void TurnOnMult(MultPool speed)
    {
        int rand = Random.Range(0, _spawnLocation.Count - 1);
        // parent and reposition(displayed) the recently borrowed pool object
        speed.transform.parent = _spawnLocation[rand];
        speed.transform.position = _spawnLocation[rand].position;

        speed.gameObject.SetActive(true);
    }
    private void TurnOffMult(MultPool speed)
    {
        // parent and reposition(hidden) the recently borrowed pool object
        speed.transform.parent = _sourceLocation;
        speed.transform.position = _sourceLocation.position;

        speed.gameObject.SetActive(false);
        Debug.Log($"Return Mult");
    }
    
    // For Slow pool
    private SlowPool SlowFactoryMethod()
    {
        GameObject obj = Instantiate(_slowPrefab) as GameObject;
        SlowPool objScript = obj.GetComponent<SlowPool>();
        // attach a reference of the objectPool to the pool object
        objScript.AssignObjectPool(_slowPool);

        obj.transform.parent = _sourceLocation;
        obj.gameObject.SetActive(false);

        return obj.GetComponent<SlowPool>();
    }

    private void TurnOnSlow(SlowPool speed)
    {
        int rand = Random.Range(0, _spawnLocation.Count - 1);
        // parent and reposition(displayed) the recently borrowed pool object
        speed.transform.parent = _spawnLocation[rand];
        speed.transform.position = _spawnLocation[rand].position;

        speed.gameObject.SetActive(true);
    }
    private void TurnOffSlow(SlowPool speed)
    {
        // parent and reposition(hidden) the recently borrowed pool object
        speed.transform.parent = _sourceLocation;
        speed.transform.position = _sourceLocation.position;

        speed.gameObject.SetActive(false);
        Debug.Log($"Return Slow");
    }
    
    [SerializeField] private int _maxSpeedSize;
    [SerializeField] private int _maxMultSize;
    [SerializeField] private int _maxSlowSize;
    // functionality for spawning bullet objects
    void Update()
    {
        if (_speedPool.GetActiveStockSize() < _maxSpeedSize)
        {
            _speedPool.GetObject();
        }
        if (_multPool.GetActiveStockSize() < _maxMultSize)
        {
            _multPool.GetObject();
        }
        if (_slowPool.GetActiveStockSize() < _maxSlowSize)
        {
            _slowPool.GetObject();
        }
    }
}
