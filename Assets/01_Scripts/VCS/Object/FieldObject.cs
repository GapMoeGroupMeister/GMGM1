using System.Collections;
using System.Collections.Generic;
using EntityManage;
using UnityEngine;

public class FieldObject : MonoBehaviour, IDamageable
{
    [SerializeField] protected int hp = 5;
    [SerializeField] protected int maxHp = 5;

    [SerializeField] private EffectObject _destoryEffect;
    public int Hp => hp;
    public int MaxHp => maxHp;

    
    
    public bool IsDestroy => hp <= 0;


    protected virtual void CheckDestroy()
    {
        if (IsDestroy)
        {
            Destroy();
        }
    }

    protected virtual void Destroy()
    {
        EffectObject effectObject = Instantiate(_destoryEffect, transform.position, Quaternion.identity);
        effectObject.Play();
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        CheckDestroy();
        
    }

    public void RestoreHealth(int amount)
    {
        hp += amount;
    }

    public void CheckDie()
    {
        throw new System.NotImplementedException();
    }
}