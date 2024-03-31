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
        // ���� ���ʹ��� ��ġ�� ����
        Vector2 currentPosition = tr.position;
        // ���� ���Ⱚ ����
        var dir = _direction == Direction.Left ? -1 : 1;

        // �̵� �������� Ray�� ���� �浹 �Ǹ� ���� ��ȯ
        if( Physics2D.Raycast(currentPosition + new Vector2(0, 0.5f), new Vector2(dir, 0), _wallRaycastDistance) )
        {
            _currentDirectionDistance = 0;
            _direction  = _direction == Direction.Left ? Direction.Right : Direction.Left;
            dir *= -1;
        }

        float move = dir * _moveSpeed * Time.deltaTime;

        // �ش� �������� �̵�
        currentPosition.x += move;
        // �̵� �� ����
        tr.position = currentPosition;

        _currentDirectionDistance += move;
        // ������ �Ÿ� ��ŭ �ش� �������� �̵�
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
