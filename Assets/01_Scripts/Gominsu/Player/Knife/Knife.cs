using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Knife : MonoBehaviour
{
    public int damage = 0;

    public GameObject knifePrefab;

    public Transform gunTip;
    public abstract void Slash();

    protected virtual void Awake()
    {
        gunTip = transform.Find("GunTip");
    }
}
