using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    Gun gun;
    [SerializeField]
    PlayerWeaponManager weaponManager;

    private void Awake()
    {
        weaponManager = GetComponent<PlayerWeaponManager>();
    }
    protected virtual void Update()
    {
        if (weaponManager.CurrentGun != null)
            gun = weaponManager.CurrentGun.GetComponent<Gun>();
        if (gun != null) 
        { 
        gun._currentTime += Time.deltaTime;
        gun._mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//마우스 위치를 월드 좌표로 변환
        Rotate();
        GunInput();
        GunRender();
        }
    }
    private void GunRender()
    {
        if (gun._player.transform.position.x > gun._mousePos.x)
        {
            gun.transform.position = new Vector3(transform.position.x + -0.7f, transform.position.y, 0);
        }
        else
        {
            gun.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, 0);
        }
    }
    private void GunInput()
    {
        if (gun.currentBulletCount <= 0 && !gun._isReloading)
        {
            gun._isReloading = true;
            gun.Reload();
        }
        if (Input.GetMouseButtonDown(1))//우클릭
        {
            //knife.Slash();
        }
        if (!gun.IsCoolTime)
        {
            return;
        }
        if (gun.isContinueFire)
        {
            if (Input.GetMouseButton(0))//좌클릭 홀드
            {
                gun._currentTime = 0;
                FireHandler();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))//좌클릭
            {
                gun._currentTime = 0;
                FireHandler();
            }
        }
    }
    protected void Rotate()
    {
        Vector2 dir = (gun._mousePos - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    protected void FireHandler()
    {
        Vector2 dir = gun._mousePos - (Vector2)transform.position;
        if (gun.reloadCheck == false) return;
        gun.currentBulletCount--;
        GameManager.Instance.playerController.OnShootEvent?.Invoke(gun.currentBulletCount, gun.maxBulletCount);
        gun.Fire(dir.normalized);
    }
}
