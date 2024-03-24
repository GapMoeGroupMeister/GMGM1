using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Throwingknife : MonoBehaviour
{
    public int damage = 0;

    public GameObject knifePrefab;

    public Transform gunTip;
    public abstract void Fire();

    protected virtual void Awake()
    {
        gunTip = transform.Find("GunTip");
    }
}
