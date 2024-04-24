using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action<float, bool, bool, bool> OnMoveMentEvent;
    public float inputx;
    public bool LeftShift;
    public bool LeftControl;
    public bool Space;



    private void Update()
    {
        inputx = (Input.GetAxis("Horizontal"));
        LeftShift = Input.GetKey(KeyCode.LeftShift);
        LeftControl = Input.GetKey(KeyCode.LeftControl);
        Space = Input.GetKeyDown(KeyCode.Space);

        OnMoveMentEvent?.Invoke(inputx,LeftShift,LeftControl,Space);
    }
}
