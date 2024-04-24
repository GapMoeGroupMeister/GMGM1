using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Gun
{

//    1. źâ 30��

//2. źȯ �� ������ 10

//3. �������� �ҿ� �ð� 5f;

//4. ź�� 1f;

//5. �����Ÿ� 12Ÿ��(Ÿ�ϸ� ����)

//6. �߻� 1 = 1 źȯ
    protected override void Awake()
    {
        base.Awake();
        
    }

    public override void Fire(Vector2 direction)
    {
        if (reloadCheck == false) return;
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().Fire(direction, damage, bulletSpeed, destroyRange, isPlayer);
        currentBulletCount--;
        if (currentBulletCount == 0)
        {
            Reload();
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
