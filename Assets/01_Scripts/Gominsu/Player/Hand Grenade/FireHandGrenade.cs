using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHandGrenade : Gun
{

    private void Awake()
    {
        base.Awake();
    }

    public override void Fire(Vector2 direction)
    {
        HandGrenade handGrenade = Instantiate(handGrenadePrefab, gunTip.position, Quaternion.identity);
        handGrenade.Fire(direction);
    }
}
