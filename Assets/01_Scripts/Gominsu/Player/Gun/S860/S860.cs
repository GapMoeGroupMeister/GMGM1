using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S860 : Gun
{
    public override void Fire(Vector2 direction)
    {
        for (int i = 0; i < 8; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
            bullet.Fire(direction.normalized);
            bullet.SetDefault(bulletSpeed, destroyRange, damage);
            Vector2 newDirection = Quaternion.Euler(new Vector3(0,0,Random.Range(-10f, 10f))) * direction;
            bullet.Fire(newDirection);           
        }            
    }
    
}
