using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun
{
    private float currentTime = 0;
    private float reloadTime = 3;

    public override void Fire()
    {
        GameObject b = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
        b.GetComponent<Bullet>().Direction = Vector2.up;

        bulletCount++;
    }

    public override void Reload()
    {
        if (bulletCount >= 30)
        {//재장전 시간
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
