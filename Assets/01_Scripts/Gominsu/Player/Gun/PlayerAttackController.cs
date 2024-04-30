using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public Gun gun;
    [SerializeField]
    PlayerWeaponManager _weaponManager;
    SpriteRenderer _spriteRenderer;

    private PlayerInput _playerInput;

    private void Awake()
    {
        
        _playerInput = GetComponent<PlayerInput>();
        _weaponManager = GetComponent<PlayerWeaponManager>();
    }

    private void Start()
    {
        _playerInput.OnMouseClick += GunInput;
    }
    protected virtual void Update()
    {
        if (_weaponManager.CurrentGun != null)
            gun = _weaponManager.CurrentGun.GetComponent<Gun>();
        if (gun != null) 
        { 
        gun._currentTime += Time.deltaTime;
        gun._mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//마우스 위치를 월드 좌표로 변환
        Rotate();
        GunRender();
            _spriteRenderer = gun.GetComponent<SpriteRenderer>();
            Flip();
        }
    }
    private void GunRender()
    {
        if (transform.position.x > gun._mousePos.x)
        {
            gun.transform.position = new Vector3(transform.position.x + -0.7f, transform.position.y, 0);
        }
        else
        {
            gun.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, 0);
        }
    }
    private void GunInput(bool Mouse0,bool MouseDown0,bool Mouse1)
    {
        if (gun != null) 
        {
            if (gun.currentBulletCount <= 0 && !gun._isReloading)
            {
                gun._isReloading = true;
                gun.Reload();
            }
            if (Mouse1)//우클릭
            {
                //knife.Slash();
            }
            if (!gun.IsCoolTime)
            {
                return;
            }
            if (gun.isContinueFire)
            {
                if (MouseDown0)//좌클릭 홀드
                {
                    gun._currentTime = 0;
                    FireHandler();
                }
            }
            else
            {
                if (Mouse0)//좌클릭
                {
                    gun._currentTime = 0;
                    FireHandler();
                }
            } 
        }
    }
    protected void Rotate()
    {
        Vector2 dir = (gun._mousePos - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    protected void FireHandler()
    {
        Vector2 dir = gun._mousePos - (Vector2)transform.position;
        if (gun.reloadCheck == false) return;
        gun.currentBulletCount--;
        GameManager.Instance.playerController.OnShootEvent?.Invoke(gun.currentBulletCount, gun.maxBulletCount);
        gun.Fire(dir.normalized);
    }

    private void Flip()
    {

        _spriteRenderer.flipY = transform.position.x > gun._mousePos.x;

    }
}
