using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : EnemyWeapon
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void Fire(Vector2 direction)
    {
        if (reloadCheck == false) return;
        currentBulletCount--;
        if (currentBulletCount <= 0)
        {
            Reload();
        }
        for (int i = 0; i < 8; i++)
        {
            //마우스의 위치에서 +-10의 랜덤한 각도를 direction에 저장하여 bullet에 전송
            direction = Quaternion.Euler(new Vector3(0, 0, Random.Range(-5f, 5f))) * direction;
            GameObject bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);

            bullet.GetComponent<EnemyBullet>().Fire(direction);
            

            bullet.GetComponent<EnemyBullet>().speed = bulletSpeed;
            bullet.GetComponent<EnemyBullet>().destroyDistance = Random.Range(13f, 15f);
        }

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
