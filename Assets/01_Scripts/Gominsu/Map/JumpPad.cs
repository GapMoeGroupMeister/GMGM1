using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpPadPower = 30f;

    public bool chackJumpPad = false;


    PlayerController _playerController;

    private void Awake()
    {
        _playerController = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (chackJumpPad)
        {
            _playerController.SuperJump(jumpPadPower);
            chackJumpPad = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            chackJumpPad = true;
        }
    }
}
