using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/EnemySO")]
public class EnemySO : ScriptableObject
{
    [SerializeField]
    private string enemy_Name;

    [SerializeField]
    private string spriteName;

    [SerializeField]
    private string enemy_AttackType;

    [SerializeField]
    private string enemy_Weapon;

    [SerializeField]
    private int enemy_HP;

    [SerializeField]
    private float enemy_RoamingRange;

    [SerializeField]
    private float enemy_MoveSpeed;

    [SerializeField]
    private float enemy_Sight;

    [SerializeField]
    private float enemy_WallSight;

    [SerializeField]
    private EnemyBullet enemy_Bullet;


    public string Enemy_Name => enemy_Name;
    public string SpriteName => spriteName;
    public int Enemy_HP => enemy_HP;
    public float Enemy_RoamingRange => enemy_RoamingRange;
    public float Enemy_MoveSpeed => enemy_MoveSpeed;    
    public float Sight => enemy_Sight;
    public float WallSight => enemy_WallSight;
    public EnemyBullet Bullet => enemy_Bullet;
}