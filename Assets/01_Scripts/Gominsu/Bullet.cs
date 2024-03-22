using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1;
    //public GameObject player;

    private float currentTime = 0;
    private float creatTime = 0.375f;

    public Vector3 Direction;

    

    private void Update()
    {
        transform.position += Direction * speed * Time.deltaTime;



        //if (transform.position.y > (player.transform.position.y + 10))
        //{
        //    Destroy(gameObject);
        //}

        currentTime += Time.deltaTime;
        if (currentTime >= creatTime)
        {
            Destroy(gameObject);
        }
    }

}
