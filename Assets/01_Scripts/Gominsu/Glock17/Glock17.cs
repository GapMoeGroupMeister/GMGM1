using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.źâ 18��

//2.������ 20

//3.�������� �ҿ� �ð� 3f;

//4.ź�� 1f;

//5.�����Ÿ� 10Ÿ��(Ÿ�ϸ� ����)

public class Glock17 : Gun
{

    private float currentTime = 0;
    private float reloadTime = 3;

    public override void Fire()
    {
        GameObject firePos = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
        firePos.GetComponent<Bullet>().Direction = Vector2.up;

        damage = 20;

    }

    public override void Reload()
    {
        

        if (bulletCount >= 18)
        {//������ �ð�
             currentTime += Time.deltaTime;
             reloadCheck = false;
            if (currentTime >= reloadTime)
            {
                reloadCheck = true;
                bulletCount = 0;
                currentTime = 0;
            }
             



        }
    }
}
