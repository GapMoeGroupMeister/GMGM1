using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Eneny : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right
    }

    [SerializeField] private float _moveSpeed = 3;
    [FormerlySerializedAs("_Hp")][SerializeField] private int _hp = 5;
    [SerializeField] private float _directionMoveDistance = 6;
    [SerializeField] private float _wallRaycastDistance = 1;

    private Direction _direction = Direction.Left;
    private float _currentDirectionDistance = 0;

    [SerializeField] private int _Hp = 5;

    void Start()
    {
        
    }

    void Update()
    {        

        var tr = transform;
        // 현재 에너미의 위치를 얻어옴
        Vector2 currentPosition = tr.position;
        // 현재 방향값 설정
        var dir = _direction == Direction.Left ? -1 : 1;

        // 이동 방향으로 Ray를 쏴서 충돌 되면 방향 전환
        if( Physics2D.Raycast(currentPosition + new Vector2(0, 0.5f), new Vector2(dir, 0), _wallRaycastDistance) )
        {
            _currentDirectionDistance = 0;
            _direction  = _direction == Direction.Left ? Direction.Right : Direction.Left;
            dir *= -1;
        }

        float move = dir * _moveSpeed * Time.deltaTime;

        // 해당 방향으로 이동
        currentPosition.x += move;
        // 이동 값 적용
        tr.position = currentPosition;

        _currentDirectionDistance += move;
        // 지정된 거리 만큼 해당 방향으로 이동
        if (_currentDirectionDistance >= _directionMoveDistance)
        {
            _directionMoveDistance = 0;
            _direction = _direction == Direction.Left ? Direction.Right : Direction.Left;
        }
    }
    public void Damage (int amout)
    {
        _Hp -= amout;
        if (_hp <= 0)
        {
            //Destroy(gameObject);
        }
    }


}
