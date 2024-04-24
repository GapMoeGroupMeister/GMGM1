using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombVest : EnemyWeapon
{
    public override void Fire(Vector2 direction)
    {
        
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
