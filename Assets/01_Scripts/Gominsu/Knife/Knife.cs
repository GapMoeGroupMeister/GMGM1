using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Throwingknife
{
    private float currentTime = 0;
    private float creatTime = 0.055f;

    GameObject knife;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= creatTime)
        {
            Destroy(knife);
            currentTime = 0;
        }

    }
    public override void Fire()
    {

        damage = 50;
        knife = Instantiate(knifePrefab, gunTip.position, Quaternion.identity);

    }
}
