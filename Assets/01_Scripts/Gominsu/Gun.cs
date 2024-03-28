using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public int damage = 0;

    public bool reloadCheck = true;

    public int maxBulletCount = 0;
    
    public int currentBulletCount = 0;

    public float fireDelay;

    public float reloadTime;

    public float bulletSpeed;

    public float destroyRange;

    public GameObject bulletPrefab;

    public Transform gunTip;
    public abstract void Fire(Vector2 direction);

    protected virtual void Awake()
    {
        gunTip = transform.Find("GunTip");
    }

    public virtual void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    protected virtual IEnumerator ReloadCoroutine()
    {
        reloadCheck = false;
        yield return new WaitForSeconds(reloadTime);
        reloadCheck = true;
        currentBulletCount = maxBulletCount;
    }
}
