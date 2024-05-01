using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Gun
{

//    1. 탄창 30발

//2. 탄환 당 데미지 10

//3. 재장전시 소요 시간 5f;

//4. 탄속 1f;

//5. 사정거리 12타일(타일맵 기준)

//6. 발사 1 = 1 탄환
    protected override void Awake()
    {
        base.Awake();

    }

    public override void Fire(Vector2 direction)
    {
        Bullet bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
        bullet.Fire(direction.normalized);
        bullet.SetDefault(bulletSpeed, destroyRange);
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
