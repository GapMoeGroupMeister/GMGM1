using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashKnife : Knife
{
    private float currentTime = 0;
    private float creatTime = 0.055f;

    private Vector2 mousePos;

    [SerializeField]
    private LayerMask enemyLayerMask;

    private void Awake()
    {
        base.Awake();
        damage = 50;
    }
    private void Start()
    {
        Rotate();   
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentTime += Time.deltaTime;
        if (currentTime >= creatTime)
        {
            currentTime = 0;
        }
        
    }


    public override void Slash()
    {
        RaycastHit2D[] py = Physics2D.BoxCastAll(new Vector2(transform.position.x, transform.position.y), new Vector2(10, 10), transform.eulerAngles.z, new Vector2(10, 10), enemyLayerMask);
        if (py != null)
        {
            Instantiate(knifePrefab, gunTip.position, Quaternion.identity);
        }
        //knife = Instantiate(knifePrefab, gunTip.position, Quaternion.identity);
    }

    private void Rotate()
    {
        Vector2 dir = (mousePos - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        knifePrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
