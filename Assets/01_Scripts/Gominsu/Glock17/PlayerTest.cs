using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public Gun gun;
    public Knife knife;

    private Vector2 mousePos;

    public float fireDelay;

    private void Start()
    {
        fireDelay = gun.fireDelay;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rotate();
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("ShootCoroutine");
               
        }
        if(Input.GetMouseButtonUp(0))
        {
            StopCoroutine("ShootCoroutine");
        }
        if (Input.GetMouseButtonDown(1))
        {
            knife.Slash();
        }
    }

    private void Rotate()
    {
        Vector2 dir = (mousePos - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void Fire()
    {
    //    Vector3 dir = Vector3.up;
    //    dir = Quaternion.Euler(0, 0, 20f) * dir;

    //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
        Vector2 dir = mousePos - (Vector2)transform.position;
        gun.Fire(dir.normalized);
    }

    IEnumerator ShootCoroutine()
    {
        while(true)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
            yield return new WaitForSeconds(fireDelay);
        }
    }
}