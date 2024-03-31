using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right
    }    

    [SerializeField] private int _enemyCode = 1;

    [SerializeField] private float _sight = 1;
    [SerializeField] private float _wallSight = 1;

    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _wallLayer;

    [SerializeField] private GameObject _findEnemyMark;
    [SerializeField] private GameObject _findWallMark;

    private float _moveSpeed = 3;
    private int _hp = 5;
    private float _directionMoveDistance = 6;
    private Vector2 moveRange;   
    private Direction _direction = Direction.Left;  

    void Start()
    {
        EnemyTableData enemyData = EnemyTable.Instance.Find(_enemyCode);
        _hp = enemyData.Enemy_HP;
        _directionMoveDistance = enemyData.Enemy_RoamingRange;
        _moveSpeed = enemyData.Enemy_MoveSpeed;

        _findEnemyMark.SetActive(false);
        _findWallMark.SetActive(false);

        Vector3 pos = transform.position;
        moveRange.x = pos.x - _directionMoveDistance;
        moveRange.y = pos.x + _directionMoveDistance;
    }

    void Update()
    {

        Transform tr = transform;
        // ���� ���ʹ��� ��ġ�� ����
        Vector2 currentPosition = tr.position;
        // ���� ���Ⱚ ����
        float dir = _direction == Direction.Left ? -1f : 1f;

        bool findWall = false;
        bool findPlayer = false;

        // �̵� �������� Ray�� ���� �浹 �Ǹ� ���� ��ȯ (Playerã��)
        RaycastHit2D hit2D = Physics2D.Raycast(currentPosition, new Vector2(dir, 0), _sight, _playerLayer);
        if (hit2D.collider != null)
        {
            findPlayer = true;            
        }        

        hit2D = Physics2D.Raycast(currentPosition, new Vector2(dir, 0), _wallSight, _wallLayer);
        if (hit2D.collider != null)
        {
            findWall = true;            
        }

        if (findPlayer && findWall )
        {
            _findEnemyMark.SetActive(false);
            _findWallMark.SetActive(true);
            return;
        }
        else if (findPlayer)
        {
            _findEnemyMark.SetActive(true);
            _findWallMark.SetActive(false);            
            return;
        }
        else if (findWall)
        {
            _findEnemyMark.SetActive(false);
            _findWallMark.SetActive(false);
            dir = ChangeDirection();
        }
        else
        {
            _findEnemyMark.SetActive(false);
            _findWallMark.SetActive(false);
        }

        float move = dir * _moveSpeed * Time.deltaTime;

        // �ش� �������� �̵�
        currentPosition.x += move;
        // �̵� �� ����
        tr.position = currentPosition;
        
        // ������ �Ÿ� ��ŭ �ش� �������� �̵�
        if (currentPosition.x <= moveRange.x || currentPosition.x >= moveRange.y)
        {
            ChangeDirection();
        }
    }

    private float ChangeDirection()
    {        
        _direction = _direction == Direction.Left ? Direction.Right : Direction.Left;
        return _direction == Direction.Left ? -1 : 1;
    }

    public void Damage (int amout)
    {
        _hp -= amout;
        if (_hp <= 0)
        {
            //Destroy(gameObject);
        }
    }
}
