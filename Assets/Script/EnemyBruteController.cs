using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBruteController : EnemyController
{
    public override void SetCanSeePlayer(bool b)
    {   
        this.canSeePlayer = b;
    }
}
