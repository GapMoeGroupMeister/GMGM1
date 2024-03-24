using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public Gun gun;
    public Knife throwingknife;
    


    private void Update()
    {
        
        gun.Reload();
        
        if (Input.GetMouseButtonDown(0) && gun.reloadCheck)
        {
            
            gun.Fire(); 

            
        }

        if (Input.GetMouseButtonDown(1))
        {

            throwingknife.Fire();

        }
        
    }

}
