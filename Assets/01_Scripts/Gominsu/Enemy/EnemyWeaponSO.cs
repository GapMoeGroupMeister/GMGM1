using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyWeaponSO")]

public class EnemyWeaponSO : ScriptableObject
{
    public int damage = 0;//������

    public int maxBulletCount = 0;//��ź��

    public float fireDelay;//���� �ӵ�

    public float reloadTime;//������ �ð�

    public float bulletSpeed;//�Ѿ� ���ǵ�

    public float destroyRange;//�����Ÿ�

    public GameObject bulletPrefab;//�Ѿ� ������
}
