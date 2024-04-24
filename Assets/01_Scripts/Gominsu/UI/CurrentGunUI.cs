using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentGunUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private CurrentGunSO[] currentGunSO;
    public int i = 0;
    

    protected virtual void Update()
    {
        _image.sprite = currentGunSO[i].image;
    }
   
}

