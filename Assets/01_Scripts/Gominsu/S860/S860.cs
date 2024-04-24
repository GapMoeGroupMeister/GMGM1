using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S860 : Gun
{
//    1. 탄창 2발

//2. 탄환 당 3데미지(최대 24 데미지)

//3. 재장전시 소요 시간 3f;

//4. 탄속 1f;

//5. 사정거리 3타일(타일맵 기준)

//6. 발사 1 = 8 탄환
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
            direction = Quaternion.Euler(new Vector3(0,0,Random.Range(-10f, 10f))) * direction;
            GameObject bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);

            Bullet bullet_clone = bullet.GetComponent<Bullet>();

            bullet_clone.Fire(direction, damage, bulletSpeed, Random.Range(3f, 5f), isPlayer);
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
