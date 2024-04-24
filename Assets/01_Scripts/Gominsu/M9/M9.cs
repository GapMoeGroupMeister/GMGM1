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
        
    }


    public override void Fire(Vector2 direction)
    {
        if (reloadCheck == false) return;//������ ���̶�� �Ʒ��ڵ�� �������
        //�Ѿ��� ���� ���콺 ��ġ�� ����
        GameObject bulletGameObject = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();
        
        bullet.Fire(direction, damage, bulletSpeed, destroyRange, isPlayer);

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
