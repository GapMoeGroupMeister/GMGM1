using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FieldObject : MonoBehaviour
{
    [SerializeField] protected int hp = 5;
    [SerializeField] protected int maxHp = 5;

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

    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        CheckDestroy();
        
    }
    
    
}