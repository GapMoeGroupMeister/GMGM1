using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class M9 : Gun
{
    public override void Fire(Vector2 direction)
    {
        Bullet bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
        bullet.Fire(direction.normalized);
        bullet.SetDefault(bulletSpeed, destroyRange);
        
        
    }

}
