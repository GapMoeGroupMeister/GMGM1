using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public Gun[] guns;
    public Knife knife;

    int i;

    [SerializeField]
    GameObject Player;

    private Vector2 mousePos;//���콺 ��ġ

    public float fireDelay;

    private void Start()
    {
        fireDelay = guns[i].fireDelay;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            i = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            i = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            i = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            i = 3;
        }


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Rotate();
        if (Input.GetMouseButtonDown(0))//��Ŭ��
        {
            StartCoroutine("ShootCoroutine");

        }
        if (Input.GetMouseButtonUp(0))//��Ŭ�� ����
        {
            StopCoroutine("ShootCoroutine");
        }
        if (Input.GetMouseButtonDown(1))//��Ŭ��
        {
            knife.Slash();
        }

        if (Player.transform.position.x > mousePos.x)
        {
            transform.position = new Vector3(Player.transform.position.x + -0.7f, Player.transform.position.y, 0);
        }
        else
        {
            transform.position = new Vector3(Player.transform.position.x + 0.7f, Player.transform.position.y, 0);
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
        guns[i].Fire(dir.normalized);
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))//��Ŭ���� ������ �ִ� ���ȿ� /����
            {
                Fire();
            }
            yield return new WaitForSeconds(fireDelay);
        }
    }


}
