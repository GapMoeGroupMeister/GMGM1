using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{
    
    Slider hpBar;

    public float speed = 3;

    public Vector3 gunTipPosition;
    public float destroyDistance = 10;


    public Vector3 Direction;//�Ѿ� ����

    public void Fire(Vector2 dir)
    {
        Direction = dir;
        gunTipPosition = transform.position;//�� ����� �ڽ��� ��ġ = �ѱ��� ��ġ 
    }

    private void Update()
    {
        transform.position += Direction * speed * Time.deltaTime;

        if (Vector2.Distance(gunTipPosition, transform.position) > destroyDistance)//���� Vector2.Distance�� destroyDistance���� ũ�ٸ� �Ѿ��� ����
        {                                                                             //   ����� transform.position - guntip(���� �̵��� �Ÿ�)�̴�
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}
