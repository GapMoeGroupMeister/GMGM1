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
        
        for (int i = 0; i < 8; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
            bullet.Fire(direction.normalized);
            bullet.SetDefault(bulletSpeed, destroyRange);
            Vector2 newDirection = Quaternion.Euler(new Vector3(0,0,Random.Range(-10f, 10f))) * direction;
            bullet.Fire(newDirection);
            
            bullet.destroyDistance = Random.Range(3f, 5f);
        }
            
    }
    protected override void Reload()
    {
        base.Reload();
    }

    protected override IEnumerator ReloadCoroutine()
    {
        return base.ReloadCoroutine();
    }
}
