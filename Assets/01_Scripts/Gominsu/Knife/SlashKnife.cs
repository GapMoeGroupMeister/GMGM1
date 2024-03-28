using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashKnife : Knife
{
    private float currentTime = 0;
    private float creatTime = 0.055f;

    private Vector2 mousePos;

    GameObject knife;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= creatTime)
        {
            Destroy(knife);
            currentTime = 0;
        }
        Rotate();

    }
    public override void Slash()
    {

        damage = 50;
        knife = Instantiate(knifePrefab, gunTip.position, Quaternion.identity);

    }

    private void Rotate()
    {
        Vector2 dir = (mousePos - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        knifePrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
