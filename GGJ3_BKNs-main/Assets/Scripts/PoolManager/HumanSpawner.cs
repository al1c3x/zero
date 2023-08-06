using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    [SerializeField] private List <Transform> _spawnLocation;
    [SerializeField] private Transform _sourceLocation;
    [SerializeField] private GameObject _humanPrefab;
    [SerializeField] private int _maxSize = 30;

    public ObjectPool<HumanPool> _objectPool;

    void Start()
    {
        if (_spawnLocation == null || _sourceLocation == null)
            Debug.LogError("Missing one or more Transform requirement!");
        if (_humanPrefab == null || _humanPrefab.GetComponent<HumanPool>() == null)
            Debug.LogError("Missing prefab or component!");
        else
        {
            _objectPool = new ObjectPool<HumanPool>(HumanFactoryMethod, TurnOnHuman, TurnOffHuman, 100, true);
        }
    }
    private HumanPool HumanFactoryMethod()
    {
        GameObject obj = Instantiate(_humanPrefab) as GameObject;
        HumanPool objScript = obj.GetComponent<HumanPool>();
        // attach a reference of the objectPool to the pool object
        objScript.AssignObjectPool(_objectPool);

        obj.transform.parent = _sourceLocation;
        obj.gameObject.SetActive(false);

        return obj.GetComponent<HumanPool>();
    }

    private void TurnOnHuman(HumanPool human)
    {
        int rand = Random.Range(0, _spawnLocation.Count - 1);
        // parent and reposition(displayed) the recently borrowed pool object
        human.transform.parent = _spawnLocation[rand];
        human.transform.position = _spawnLocation[rand].position;

        human.gameObject.SetActive(true);
    }
    private void TurnOffHuman(HumanPool human)
    {
        // parent and reposition(hidden) the recently borrowed pool object
        human.transform.parent = _sourceLocation;
        human.transform.position = _sourceLocation.position;

        human.gameObject.SetActive(false);
    }

    // functionality for spawning bullet objects
    void Update()
    {
        if (_objectPool.GetActiveStockSize() < _maxSize)
        {
            _objectPool.GetObject();
            //Debug.LogError($"Spawn!!: {_objectPool.GetActiveStockSize()}");
        }
    }
}
