using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public int damage = 0;//������

    public bool reloadCheck = true;//������ üũ

    public int maxBulletCount = 0;//��ź��
    
    public int currentBulletCount = 0;

    public float fireDelay;//���� �ӵ�

    public float reloadTime;//������ �ð�

    public float bulletSpeed;//�Ѿ� ���ǵ�

    public float destroyRange;//�����Ÿ�

    public GameObject bulletPrefab;//�Ѿ� ������

    public Transform gunTip;//�ѱ� ��ġ
    public abstract void Fire(Vector2 direction);

    protected virtual void Awake()
    {
        gunTip = transform.Find("GunTip");//�ѱ���ġ �޾ƿ�
    }

    public virtual void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    protected virtual IEnumerator ReloadCoroutine()
    {
        reloadCheck = false;
        yield return new WaitForSeconds(reloadTime);//reloadTime��ŭ ��ٷȴٰ� �ؿ� �ڵ带 ����
        reloadCheck = true;
        currentBulletCount = maxBulletCount;
    }
}
