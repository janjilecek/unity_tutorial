using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Observer pattern variables")] 
    public GameObject objCar1;
    public GameObject objCar2;
    public GameObject objCar3;

    [Header("State pattern variables")] 
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject player;
    
    Subject _subject = new Subject();
    List<EnemyInterface> enemies = new List<EnemyInterface>();
    
    void Start()
    {
        enemies.Add(new Alpha(enemy1.transform));
        enemies.Add(new Beta(enemy2.transform));
        
        Car car1 = new Car(objCar1, new MoveBack());
        Car car2 = new Car(objCar2, new MoveUp());
        Car car3 = new Car(objCar3, new MoveLeft());
        
        _subject.AddObserver(car1);
        _subject.AddObserver(car2);
        _subject.AddObserver(car3);
    }

    private void Update()
    {
        foreach (var enemy in enemies)
        {
            enemy.UpdateEnemy(player.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _subject.Notify();
        }
    }
}
