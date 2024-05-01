using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombVest : EnemyBomb
{
    public override void Fire()
    {
        Destroy(gameObject);
    }
}
