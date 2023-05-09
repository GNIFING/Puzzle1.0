using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlerterController : EnemyController
{
    public override void SetCanSeePlayer(bool b)
    {   
        this.canSeePlayer = b;
        EnemyController[] allEnemies = GameObject.FindObjectsOfType<EnemyController>();
        foreach (EnemyController enemy in allEnemies)
        {
            // if(enemy.GetType().ToString() != "EnemyAlerterController"){
            //     enemy.alert(b, this.lastSeenPosition);
            // }
            enemy.setIsAlert(b);
            if(b){
                enemy.SetLastSeenPosition(this.lastSeenPosition);
            }
        }
    }
}
