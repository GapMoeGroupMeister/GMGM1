using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestBomb : MonoBehaviour
{

    public EnemyWeapon guns;

    GameObject Player;

    private Vector2 mousePos;//마우스 위치

    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//마우스 위치를 월드 좌표로 변환
        Rotate();

        if (Input.GetMouseButtonDown(0))//좌클릭
        {

            StartCoroutine("_3");

        }
        if (Input.GetMouseButtonUp(0))//좌클릭 해제
        {
            StopCoroutine("_3");
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
        guns.Fire(dir);
    }

    IEnumerator _3()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))//좌클릭이 눌리고 있는 동안에 연사
            {
                Fire();
            }
            yield return new WaitForSeconds(guns.fireDelay);
        }
    }

}
