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
    [SerializeField] private float _wallSight2 = 1;

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
        // 현재 에너미의 위치를 얻어옴
        Vector2 currentPosition = tr.position;
        Vector2 currentPosition2 = tr.position + new Vector3(0, -0.1f);
        // 현재 방향값 설정
        float dir = _direction == Direction.Left ? -1f : 1f;

        bool findWall1 = false;
        bool findWall2 = false;
        bool findPlayer = false;


        // 이동 방향으로 Ray를 쏴서 충돌 되면 방향 전환 (Player찾기)
        //RaycastHit2D hit2D = Physics2D.Raycast(currentPosition, new Vector2(dir, 0), _sight, _playerLayer);
        //if (hit2D.collider != null)
        //{
        //    findPlayer = true;
        //}
        //RaycastHit2D hit = Physics2D.Raycast(currentPosition2, new Vector2(dir, 0), _wallSight, _wallLayer);
        //if (hit.collider != null)
        //{
        //    findWall = true;
        //}

        RaycastHit2D hit2D = Physics2D.Raycast(currentPosition, new Vector2(dir, 0), _sight, _playerLayer);
        if (hit2D.collider != null)
        {
            findPlayer = true;
        }

        if (findPlayer) 
        {
            RaycastHit2D hit = Physics2D.Raycast(currentPosition2, new Vector2(dir, 0), _wallSight, _wallLayer);
            if (hit.collider != null)
            {
                findWall1 = true;
            }
        }

        if (!findPlayer)
        {
            RaycastHit2D hit2 = Physics2D.Raycast(currentPosition2, new Vector2(dir, 0), _wallSight2, _wallLayer);
            if (hit2.collider != null)
            {
                findWall2 = true;
            }
        }

        Debug.DrawRay(currentPosition, new Vector2(dir, 0), Color.green);
        Debug.DrawRay(currentPosition2, new Vector2(dir, 0), Color.blue);

        print("wall " + findWall1 + " / player : " + findPlayer);

        if (findPlayer && findWall1)
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
        else if (findWall2)
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

        // 해당 방향으로 이동
        currentPosition.x += move;
        // 이동 값 적용
        tr.position = currentPosition;
        
        // 지정된 거리 만큼 해당 방향으로 이동
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
