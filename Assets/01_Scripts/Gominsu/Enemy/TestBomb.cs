using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBomb : MonoBehaviour
{


    public EnemyBomb Weapon;
    private void Fire()
    { 
        Weapon.Fire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Fire();
        }
    }
}
