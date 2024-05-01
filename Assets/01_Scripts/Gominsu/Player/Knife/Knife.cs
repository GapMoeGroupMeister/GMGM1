using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Knife : MonoBehaviour
{
    public int damage = 0;

    public GameObject knifePrefab;

    public Transform gunTip;

    public Transform player;
    public abstract void Slash();

    protected virtual void Awake()
    {
        player = GameObject.Find("Player").transform;
        gunTip = transform.Find("GunTip");
    }
}
