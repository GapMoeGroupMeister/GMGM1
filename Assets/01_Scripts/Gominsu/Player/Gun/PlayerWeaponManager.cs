using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] gunPrefab;
    public GameObject gun;
    public GameObject CurrentGun;
    public Gun _gun;
    PlayerInput _playerInput;
    bool changeCheck = false;
    int _gunPrefab = 0;
    int currentGun = 0;

    CurrentGunUI currentGunUI;

    private void Awake()
    {
        currentGunUI = FindObjectOfType<CurrentGunUI>();
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Start()
    {
        _playerInput.OnChangeGun += ChangeWeapon;
    }
    private void Update()
    {

    }
    void ChangeWeapon(int gunIndex)
    {
        currentGun = gunIndex;
        if (currentGun > 0)
        {
            _gunPrefab = gunIndex - 1;
            InputCheck();
        }

        //if (_1)
        //{
        //    currentGun = 1;
        //    _gunPrefab = 0;
        //    InputCheck();

        //}
        //else if (_2)
        //{
        //    currentGun = 2;
        //    _gunPrefab = 1;
        //    InputCheck();
        //}
        //else if (_3)
        //{
        //    currentGun = 3;
        //    _gunPrefab = 2;
        //    InputCheck();
        //}
        //else if (_4)
        //{
        //    if (changeCheck)
        //        return;
        //    StartCoroutine("ChangeCheck");
        //    Destroy(gun);
        //    currentGunUI.i = 0;
        //}
    }

    void InputCheck()
    {
        
        if (changeCheck)    
            return;
        if(_gun != null && _gun._isReloading)
            return;
        StartCoroutine("ChangeCheck");
        Destroy(gun);
        gun = Instantiate(gunPrefab[_gunPrefab], gameObject.transform);
        gun.transform.position = transform.position;
        
        
        CurrentGun = gun;
        currentGunUI.i = currentGun;
        _gun = FindObjectOfType<Gun>();
        GameManager.Instance.RefreshBullet(_gun.currentBulletCount, _gun.maxBulletCount);
    }

    IEnumerator ChangeCheck()
    {
        changeCheck = true;
        yield return new WaitForSeconds(0.5f);
        changeCheck = false;
    }
}
