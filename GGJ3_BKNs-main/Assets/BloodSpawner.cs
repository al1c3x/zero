using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnLocation;
    [SerializeField] private Transform _sourceLocation;
    [SerializeField] private GameObject _BloodPrefab;
    [SerializeField] private GameObject _ChunkPrefab;
   

    private ObjectPool<HumanBlood> _BloodPool;
    private ObjectPool<ZombieChunk> _ChunkPool;
  
    void Start()
    { 
        
        if (_spawnLocation == null || _sourceLocation == null)
            Debug.LogError("Missing one or more Transform requirement!");
        // for speed pool
        if (_BloodPool == null )
            Debug.LogError("Missing prefab or component!");
        else
        {
            _BloodPool = new ObjectPool<HumanBlood>(BloodPoolFactoryMethod, TurnOnBloodPool, TurnOffBloodPool, 5, true);
        }
        // for mult pool
        if (_ChunkPool == null )
            Debug.LogError("Missing prefab or component!");
        else
        {
            _ChunkPool = new ObjectPool<ZombieChunk>(ZombieChunkFactoryMethod, TurnOnZombieChunk, TurnOffZombieChunk, 5, true);
        }
       
    }

    // For speed pool
    private HumanBlood BloodPoolFactoryMethod()
    {
        GameObject obj = Instantiate(_BloodPrefab) as GameObject;
        HumanBlood objScript = obj.GetComponent<HumanBlood>();
        // attach a reference of the objectPool to the pool object
        objScript.AssignObjectPool(_BloodPool);

        obj.transform.parent = _sourceLocation;
        obj.gameObject.SetActive(false);

        return obj.GetComponent<HumanBlood>();
    }

    private void TurnOnBloodPool(HumanBlood blood)
    {
        // parent and reposition(displayed) the recently borrowed pool object
        blood.transform.parent = _spawnLocation;
        blood.transform.position = _spawnLocation.position;

        blood.gameObject.SetActive(true);
    }
    private void TurnOffBloodPool(HumanBlood blood)
    {
        // parent and reposition(hidden) the recently borrowed pool object
        blood.transform.parent = _sourceLocation;
        blood.transform.position = _sourceLocation.position;

        blood.gameObject.SetActive(false);
    }

    // For Mult pool
    private  ZombieChunk ZombieChunkFactoryMethod()
    {
        GameObject obj = Instantiate(_ChunkPrefab) as GameObject;
        ZombieChunk objScript = obj.GetComponent<ZombieChunk>();
        // attach a reference of the objectPool to the pool object
        objScript.AssignObjectPool(_ChunkPool);

        obj.transform.parent = _sourceLocation;
        obj.gameObject.SetActive(false);

        return obj.GetComponent<ZombieChunk>();
    }

    private void TurnOnZombieChunk(ZombieChunk chunk)
    {
        // parent and reposition(displayed) the recently borrowed pool object
       chunk.transform.parent = _spawnLocation;
        chunk.transform.position = _spawnLocation.position;

        chunk.gameObject.SetActive(true);
    }
    private void TurnOffZombieChunk(ZombieChunk chunk)
    {
        // parent and reposition(hidden) the recently borrowed pool object
        chunk.transform.parent = _sourceLocation;
        chunk.transform.position = _sourceLocation.position;

        chunk.gameObject.SetActive(false);
    }

    // For Slow pool
  
    // functionality for spawning bullet objects
    void Update()
    {

    }
}
