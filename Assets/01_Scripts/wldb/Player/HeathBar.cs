using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    float currentHp = 100f;
    float maxHp = 100f;
    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private GameObject Player;

    private void Start()
    {
        hpBar.value = currentHp / maxHp;
    }

    private void Update()
    {

        HandleHp();


    }


    private void HandleHp()
    {
        hpBar.value = currentHp / maxHp;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    currentHp -= 10;
        //    Debug.Log(currentHp);
        //}

       if (currentHp <= 0)
        {
            Destroy(Player);
        }



        //Vector3 PlayerPos = Player.transform.position;
        //transform.position = PlayerPos;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        currentHp -= 10;
    //    }
    //}


}
