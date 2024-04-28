using System;
using UnityEngine;

[Serializable]
public class EnemyTableData
{
    [SerializeField]
    private int code;

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

    public int Code => code;
    public string Enemy_Name => enemy_Name;
    public string SpriteName => spriteName;
    public int Enemy_HP => enemy_HP;
    public float Enemy_RoamingRange => enemy_RoamingRange;
    public float Enemy_MoveSpeed => enemy_MoveSpeed;
}