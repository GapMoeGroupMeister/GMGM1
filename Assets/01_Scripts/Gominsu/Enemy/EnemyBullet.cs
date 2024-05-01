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


    public Vector3 Direction;//총알 방향

    public void Fire(Vector2 dir)
    {
        Direction = dir;
        gunTipPosition = transform.position;//쏠때 당시의 자신의 위치 = 총구의 위치 
    }

    private void Update()
    {
        transform.position += Direction * speed * Time.deltaTime;

        if (Vector2.Distance(gunTipPosition, transform.position) > destroyDistance)//만약 Vector2.Distance가 destroyDistance보다 크다면 총알을 삭제
        {                                                                             //   ㄴ얘는 transform.position - guntip(현재 이동한 거리)이다
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}
