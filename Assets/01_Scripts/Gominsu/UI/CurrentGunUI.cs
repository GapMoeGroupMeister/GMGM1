using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentGunUI : MonoBehaviour
{
    [SerializeField] private Image _image;

    int i = 0;
    [SerializeField] private CurrentGunSO[] currentGunSO;

    private void OnValidate()
    {
        if (currentGunSO[i] != null)
        {
            _image.sprite = currentGunSO[i].image;
        }
    }
    private void Update()
    {
        ChangeGun();
    }
    void ChangeGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            i = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            i = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            i = 2;
        }
    }
}

