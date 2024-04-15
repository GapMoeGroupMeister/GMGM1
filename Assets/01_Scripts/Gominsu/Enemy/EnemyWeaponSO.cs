using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyWeaponSO")]

public class EnemyWeaponSO : ScriptableObject
{
    public int damage = 0;//데미지

    public int maxBulletCount = 0;//총탄수

    public float fireDelay;//연사 속도

    public float reloadTime;//재장전 시간

    public float bulletSpeed;//총알 스피드

    public float destroyRange;//사정거리

    public GameObject bulletPrefab;//총얼 프리펩
}
