using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beta: EnemyInterface
{
    private EnemyStates betaState = EnemyStates.Attack;

    private int hp = 100;

    public Beta(Transform objAlpha)
    {
        base.objEnemy = objAlpha;
    }

    public override void UpdateEnemy(Transform objPlayer)
    {
        float distanceToPlayer = (base.objEnemy.position - objPlayer.position).magnitude;
        
        switch (betaState)
        {
            case EnemyStates.Walk:
                if (distanceToPlayer < 0.5f)
                {
                    betaState = EnemyStates.Attack;
                }
                break;
            case EnemyStates.Attack:
                if (hp < 50)
                {
                    betaState = EnemyStates.Walk;
                }
                break;
            
        }
        
        DoAction(objPlayer, betaState);
    }
}