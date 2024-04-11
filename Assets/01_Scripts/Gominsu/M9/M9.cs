using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.탄창 18발

//2.데미지 20

//3.재장전시 소요 시간 3f;

//4.탄속 1f;

//5.사정거리 10타일(타일맵 기준)

public class M9 : Gun
{
    protected override void Awake()
    {
        base.Awake();
        maxBulletCount = 9;
        currentBulletCount = maxBulletCount;
        damage = 7;
        bulletSpeed = 10;
        destroyRange = 7;
        reloadTime = 3;
    }

    public override void Fire(Vector2 direction)
    {
        if (reloadCheck == false) return;//재장전 중이라면 아래코드들 실행안함
        //총알의 방향 마우스 위치로 설정
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Fire(direction);
        currentBulletCount--;
        if (currentBulletCount == 0)
        {
            Reload();
        }
        bullet.GetComponent<Bullet>().speed = bulletSpeed;
        bullet.GetComponent<Bullet>().destroyDistance = destroyRange;
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
