using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBomb : MonoBehaviour
{
    public int damage = 0;//µ¥¹ÌÁö

    public abstract void Fire();

    public GameObject _player;

    public PlayerController _playerController;

    protected virtual void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _player = GameObject.Find("Player");
        damage = 50;
    }

}
