using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Test : MonoBehaviour
{
    public Gun gun;

    private float currentTime = 0f;
    private float createTime = 0.05f;
    private void Update()
    {
        gun.Reload();
        
        currentTime += Time.deltaTime;
        if (currentTime > createTime) 
        {
            if (Input.GetMouseButton(1) && gun.reloadCheck)
            {
                gun.Fire();
            }
            currentTime = 0;
        }
    }
}
