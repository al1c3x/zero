using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HumanScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private float Cooldown = 4.0f;
    private float nextLoc;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit path;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out path, radius, 1))
        {
            finalPosition = path.position;
        }
        return finalPosition;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLoc)
        {
            nextLoc = Time.time + Cooldown;

            agent.SetDestination(RandomNavmeshLocation(60f));
        }
    }
}
