using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public int damage = 0;

    public bool reloadCheck = true;

    public int bulletCount = 0;
    
    public int remainBulletBount = 0;

    public GameObject bulletPrefab;

    public Transform gunTip;
    public abstract void Fire();
    public abstract void Reload();

    protected virtual void Awake()
    {
        gunTip = transform.Find("GunTip");
    }


}
