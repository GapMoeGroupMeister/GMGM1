using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Action<float> OnMovementEvent;
    public Action<bool> OnJumpEvent;
    public Action<bool> OnRunEvent;
    public Action<bool> OnSitEvent;
    public Action<bool,bool> OnMouseClick;
    public Action<Vector2> MouseScrall;
    public Action<int> WeaponChange;

    public float inputx = 0;
    public bool LeftShift;
    public bool LeftControl;
    public bool Space;
    public bool Mouse0;
    public bool MouseDown0;
    PlayerWeaponManager _playerWeaponManager;

    private void Awake()
    {
        _playerWeaponManager = GameObject.Find("Player").GetComponent<PlayerWeaponManager>();
    }

    private void Update()
    {
        if (GameManager.Instance.CanPlayerControl) return;

        Mouse0 = Input.GetMouseButtonDown(0);
        MouseDown0 = Input.GetMouseButton(0);

        Vector2 vec = Mouse.current.scroll.ReadValue();

        if (Mouse0 || MouseDown0)
            OnMouseClick?.Invoke(Mouse0, MouseDown0);

        if(vec != Vector2.zero)
        MouseScrall?.Invoke(vec);

        if (_playerWeaponManager.currentIndex != _playerWeaponManager.index)
        {
            WeaponChange?.Invoke(_playerWeaponManager.index);
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 vector = value.Get<Vector2>();
        OnMovementEvent?.Invoke(vector.x);
    }

    public void OnJump(InputValue value)
    {
        
        bool jump = value.isPressed;
        OnJumpEvent?.Invoke(jump);
    }

    public void OnRun(InputValue value)
    {
        bool run = value.isPressed;
        OnRunEvent?.Invoke(run);
    }

    public void OnSit(InputValue value)
    {
        bool sit = value.isPressed;
        OnSitEvent?.Invoke(sit);
    }
}
