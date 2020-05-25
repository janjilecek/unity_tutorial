using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Transform target;
    public GameObject deathSplash;
    
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        pathfinder.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            if (Mathf.Abs(other.attachedRigidbody.velocity.x) > 5f ||
                Mathf.Abs(other.attachedRigidbody.velocity.y) > 5f ||
                Mathf.Abs(other.attachedRigidbody.velocity.z) > 5f)
            {
                Instantiate(deathSplash, transform.position, Quaternion.identity);
                GameObject.Destroy(gameObject);    
            }
            
        }
    }
}
