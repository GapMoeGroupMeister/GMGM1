using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerController _playerController;
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        _playerController._AnimaWalk += Walk;
        _playerController._AnimaRun += Run;
        _playerController._AnimaJump += Jump;
        _playerController._AnimaSliding += Sliding;
    }

    void Walk(bool isTrue)
    {
        _animator.SetBool("PlayerWalk", isTrue);
    }

    void Run(bool isTrue)
    {
        _animator.SetBool("PlayerRun", isTrue);
    }

    void Jump(bool isTrue)
    {
        _animator.SetBool("PlayerJump", isTrue);
    }

    void Sliding(bool isTrue)
    {
        _animator.SetBool("PlayerSliding", isTrue);
    }

}
