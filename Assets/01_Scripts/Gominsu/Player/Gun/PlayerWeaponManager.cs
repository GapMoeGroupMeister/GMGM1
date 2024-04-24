using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] gunPrefab;
    public GameObject gun;

    public GameObject CurrentGun;

    bool changeCheck = false;

    int _gunPrefab = 0;
    int a = 0;

    CurrentGunUI currentGunUI;

    private void Awake()
    {

        currentGunUI = FindObjectOfType<CurrentGunUI>();
    }
    private void Update()
    {
        ChnageWeapon();
    }
    void ChnageWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            a = 1;
            _gunPrefab = 0;
            InputCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            a = 2;
            _gunPrefab = 1;
            InputCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            a = 3;
            _gunPrefab = 2;
            InputCheck();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (changeCheck)
                return;
            StartCoroutine("ChangeCheck");
            Destroy(gun);
            currentGunUI.i = 0;
        }
    }

    void InputCheck()
    {
        if (changeCheck)
            return;
        StartCoroutine("ChangeCheck");
        Destroy(gun);
        gun = Instantiate(gunPrefab[_gunPrefab], gameObject.transform);
        gun.transform.position = transform.position;
        CurrentGun = gun;
        currentGunUI.i = a;
    }

    IEnumerator ChangeCheck()
    {
        changeCheck = true;
        yield return new WaitForSeconds(3f);
        changeCheck = false;
    }
}
