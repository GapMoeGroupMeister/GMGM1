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

    public int index = 0;
    public int currentIndex = 0;

    CurrentGunUI currentGunUI;

    private void Awake()
    {
        currentGunUI = FindObjectOfType<CurrentGunUI>();
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Start()
    {
        _playerInput.MouseScrall += MouseScrallCheck;
        _playerInput.WeaponChange += ChangeWeapon;
    }
    private void Update()
    {
        
    }
    void ChangeWeapon(int idx)
    {
        print(idx);
        currentGun = idx;
        if (currentGun > 0)
        {
            print("½ÇÇà");
            _gunPrefab = idx - 1;
            InputCheck();
        }
        currentIndex = index;
    }

    void MouseScrallCheck(Vector2 vec)
    {

        if (_gun != null &&_gun._isReloading)
        {
            return;
        }
            
        if (vec.y <= -120 && index < 3)
        {
            currentIndex = index;
            index++;
            index = Mathf.Clamp(index, 1, 3);
        }
        else if (vec.y >= 120 && index > 1)
        {
            currentIndex = index;
                index--;
                index = Mathf.Clamp(index, 1, 3); 
        }
    }

    void InputCheck()
    {
        if (changeCheck)    
            return;
        if (_gun != null && _gun._isReloading)
            return;
        StartCoroutine("ChangeCheck");
        Destroy(gun);
        print(gun);
        gun = Instantiate(gunPrefab[_gunPrefab], gameObject.transform);
        gun.transform.position = transform.position;

        print(gun);


        CurrentGun = gun;
        if( currentGunUI != null )
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
