using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1 : MonoBehaviour
{
    //public Gun gun;
    public Gun guns;
    public Knife knife;
    GameObject Player;


    private void Awake()
    {
        Player = GameObject.Find("Player");
        print(Player);
    }

    private void Update() 
    {
        
    }

   
}