using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action<float, bool, bool, bool> OnMoveMentEvent;
    public Action<bool,bool,bool> OnMouseClick;
    public Action<bool,bool,bool,bool> OnChangeGun;

    public float inputx = 0;
    public bool LeftShift;
    public bool LeftControl;
    public bool Space;
    public bool Mouse0;
    public bool MouseDown0;
    public bool Mouse1;
    public bool _1;
    public bool _2;
    public bool _3;
    public bool _4;



    private void Update()
    {
        _1 = Input.GetKeyDown(KeyCode.Alpha1);
        _2 = Input.GetKeyDown(KeyCode.Alpha2);
        _3 = Input.GetKeyDown(KeyCode.Alpha3);
        _4 = Input.GetKeyDown(KeyCode.Alpha4);

        Mouse0 = Input.GetMouseButtonDown(0);
        MouseDown0 = Input.GetMouseButton(0);
        Mouse1 = Input.GetMouseButton(1);

        inputx = (Input.GetAxis("Horizontal"));
        LeftShift = Input.GetKey(KeyCode.LeftShift);
        LeftControl = Input.GetKey(KeyCode.LeftControl);
        Space = Input.GetKeyDown(KeyCode.Space);

        if ((_1 || _2) || (_3||_4))
            OnChangeGun?.Invoke(_1,_2,_3,_4);
        if ((Mouse0 || MouseDown0) || Mouse1)
        OnMouseClick?.Invoke(Mouse0, MouseDown0, Mouse1);
        if (inputx != 0)
        OnMoveMentEvent?.Invoke(inputx,LeftShift,LeftControl,Space);
    }
}
