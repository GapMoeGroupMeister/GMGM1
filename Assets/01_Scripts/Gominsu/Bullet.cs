using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 3;

    public Vector3 gunTipPosition;
    public float destroyDistance = 10;


    public Vector3 Direction;

    public void Fire(Vector2 dir)
    {
        Direction = dir;
        gunTipPosition = transform.position;

    }

    private void Update()
    {
        transform.position += Direction * speed * Time.deltaTime;

        if(Vector2.Distance(gunTipPosition, transform.position) > destroyDistance)
        {
            Destroy(gameObject);
        }
    }

}
