using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.źâ 18��

//2.������ 20

//3.�������� �ҿ� �ð� 3f;

//4.ź�� 1f;

//5.�����Ÿ� 10Ÿ��(Ÿ�ϸ� ����)

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
        if (reloadCheck == false) return;//������ ���̶�� �Ʒ��ڵ�� �������
        //�Ѿ��� ���� ���콺 ��ġ�� ����
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
