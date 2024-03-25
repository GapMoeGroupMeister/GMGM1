using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.탄창 18발

//2.데미지 20

//3.재장전시 소요 시간 3f;

//4.탄속 1f;

//5.사정거리 10타일(타일맵 기준)

public class Glock17 : Gun
{

    private float currentTime = 0;
    private float reloadTime = 3;

    private void Awake()
    {
        bulletCount = 18;
        damage = 20;
    }

    public override void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
        //bullet.GetComponent<Bullet>().Direction = Vector3.up;
        bullet.GetComponent<Bullet>().Fire(Vector2.up);
        
        bulletCount--;
        


    }

    public override void Reload()
    {


        if (bulletCount <= 0)
        {
            
            
            currentTime += Time.deltaTime;

            reloadCheck = false;


            if (currentTime >= reloadTime)
            {   
                
                reloadCheck = true;
                bulletCount = 18;
                currentTime = 0;
            }
            
        }
    }
}
