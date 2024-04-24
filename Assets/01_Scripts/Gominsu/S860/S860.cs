using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S860 : Gun
{
//    1. źâ 2��

//2. źȯ �� 3������(�ִ� 24 ������)

//3. �������� �ҿ� �ð� 3f;

//4. ź�� 1f;

//5. �����Ÿ� 3Ÿ��(Ÿ�ϸ� ����)

//6. �߻� 1 = 8 źȯ
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
            //���콺�� ��ġ���� +-10�� ������ ������ direction�� �����Ͽ� bullet�� ����
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
