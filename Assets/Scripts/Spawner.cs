using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public Enemy enemy;
    private List<Enemy> enemies;
    
    [Range (0,100)]
    public int numberOfEnemies = 25;
    private float range = 70.0f;
    
    void Start()
    {
        enemies = new List<Enemy>(); // init as type
        for (int index = 0; index < numberOfEnemies; index++)
        {
            Enemy spawned = Instantiate(enemy, RandomNavmeshLocation(range), Quaternion.identity) as Enemy;
            enemies.Add(spawned);
        }
    }
    
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
