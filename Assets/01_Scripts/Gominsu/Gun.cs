using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public int damage = 0;//데미지

    public bool reloadCheck = true;//재장전 체크

    public int maxBulletCount = 0;//총탄수
    
    public int currentBulletCount = 0;

    public float fireDelay;//연사 속도

    public float reloadTime;//재장전 시간

    public float bulletSpeed;//총알 스피드

    public float destroyRange;//사정거리

    public GameObject bulletPrefab;//총얼 프리펩

    public Transform gunTip;//총구 위치
    public abstract void Fire(Vector2 direction);

    protected virtual void Awake()
    {
        gunTip = transform.Find("GunTip");//총구의치 받아옴
    }

    public virtual void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    protected virtual IEnumerator ReloadCoroutine()
    {
        reloadCheck = false;
        yield return new WaitForSeconds(reloadTime);//reloadTime만큼 기다렸다가 밑에 코드를 실행
        reloadCheck = true;
        currentBulletCount = maxBulletCount;
    }
}
