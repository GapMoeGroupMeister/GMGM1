using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] gunPrefab;
    GameObject gun1, gun2, gun3;

    public GameObject CurrentGun;

    private void Update()
    {
        ChnageWeapon();
    }
    void ChnageWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(gun1);
            gun1 = Instantiate(gunPrefab[0], gameObject.transform);
            gun1.transform.position = transform.position;
            CurrentGun = gun1;
            Destroy(gun2);
            Destroy(gun3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(gun2);
            gun2 = Instantiate(gunPrefab[1], gameObject.transform);
            gun2.transform.position = transform.position;
            CurrentGun = gun2;
            Destroy(gun1);
            Destroy(gun3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(gun3);
            gun3 = Instantiate(gunPrefab[2], gameObject.transform);
            gun3.transform.position = transform.position;
            CurrentGun = gun3;
            Destroy(gun1);
            Destroy(gun2);
        }
    }
}
