using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : EnemyInterface
{
    private EnemyStates alphaState = EnemyStates.Attack;

    private int hp = 100;

    public Alpha(Transform objAlpha)
    {
        base.objEnemy = objAlpha;
    }

    public override void UpdateEnemy(Transform objPlayer)
    {
        float distanceToPlayer = (base.objEnemy.position - objPlayer.position).magnitude;
        
        switch (alphaState)
        {
            case EnemyStates.Walk:
                if (distanceToPlayer < 5f)
                {
                    alphaState = EnemyStates.Attack;
                }
                break;
            case EnemyStates.Attack:
                if (hp < 5)
                {
                    alphaState = EnemyStates.Walk;
                }
                break;
            
        }
        
        DoAction(objPlayer, alphaState);
    }
}