using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healspat : MonoBehaviour
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
       
        //UseHeal();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            currentHp -= 10;
        }
        Debug.Log(currentHp);
    }


    //private void UseHeal()
    //{
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        currentHp += 10;
    //    }
    //}

    




}
