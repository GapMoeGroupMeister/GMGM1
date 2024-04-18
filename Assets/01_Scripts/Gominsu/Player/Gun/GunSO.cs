using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/GunSO")]

public class GunSO : ScriptableObject
{

    public int damage = 0;//데미지

    public int maxBulletCount = 0;//총탄수

    public float fireDelay;//연사 속도

    public float reloadTime;//재장전 시간

    public bool isContinueFire;
    
    public float bulletSpeed;//총알 스피드

    public float destroyRange;//사정거리

    public Bullet bulletPrefab;//총알 프리팹
    

}
