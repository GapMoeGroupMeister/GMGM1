using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AWP : EnemyWeapon
{
    protected override void Awake()
    {
        base.Awake();

    }

    public override void Fire(Vector2 direction)
    {
        if (reloadCheck == false) return;
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet>().Fire(direction);
        currentBulletCount--;
        if (currentBulletCount == 0)
        {
            Reload();
        }
        bullet.GetComponent<EnemyBullet>().speed = bulletSpeed;
        bullet.GetComponent<EnemyBullet>().destroyDistance = destroyRange;
    }
    public override void Reload()
    {
        base.Reload();
    }

    protected override IEnumerator ReloadCoroutine()
    {
        return base.ReloadCoroutine();
    }
}
