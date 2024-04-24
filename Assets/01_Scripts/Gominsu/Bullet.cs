using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage= 1;
    private float speed = 3;

    private Vector3 gunTipPosition;
    private float destroyDistance = 10;


    private Vector3 direction;//�Ѿ� ����

    private bool isPlayer;

    public void Fire(Vector2 dir, int damage, float speed, float destroyDistance, bool isPlayer)
    {
        this.direction = dir;
        this.damage = damage;
        this.speed = speed;
        this.destroyDistance = destroyDistance;
        this.isPlayer = isPlayer;


        gunTipPosition = transform.position;//�� ����� �ڽ��� ��ġ = �ѱ��� ��ġ 
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if(Vector2.Distance(gunTipPosition, transform.position) > destroyDistance)//���� Vector2.Distance�� destroyDistance���� ũ�ٸ� �Ѿ��� ����
        {                                                                             //   ����� transform.position - guntip(���� �̵��� �Ÿ�)�̴�
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( isPlayer )
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.Damage(damage);
            }
        }
        
        Destroy(gameObject);
    }
}
