using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInterface
{
    protected Transform objEnemy;

    protected enum EnemyStates
    {
        Attack,
        Walk
    }

    public virtual void UpdateEnemy(Transform objPlayer)
    {
        
    }

    protected void DoAction(Transform objPlayer, EnemyStates enemyState)
    {
        float walkSpeed = 5f;
        float attackSpeed = 3f;

        switch (enemyState)
        {
            case EnemyStates.Attack:
                // attack function
                break;
            case EnemyStates.Walk:
                // follow player
                break;
        }
    }
}