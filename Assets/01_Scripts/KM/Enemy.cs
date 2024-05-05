using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public enum EnemyState
{    
    Roaming,
    Attack
}

public class Enemy : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right
    }


    [SerializeField] private TextMeshPro stateText;
    [SerializeField] private TextMeshPro hpText;

    [SerializeField] private EnemySO _enemySO;

    [SerializeField] private float _sight = 1;
    [SerializeField] private float _wallSight = 1;

    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _wallLayer;

    [SerializeField] private GameObject _findEnemyMark;
    [SerializeField] private GameObject _findWallMark;

    [SerializeField] private PlayerController player;
    [SerializeField] private Transform gunTip;

    private EnemyState enemyState = EnemyState.Roaming;

    private float _moveSpeed = 3;
    private int _hp = 5;
    private float _directionMoveDistance = 6;
    private Vector2 moveRange;   
    private Direction _direction = Direction.Left;
    
    private float gunFireDelay = 0;
    
    bool playerInSight = false;


    void Start()
    {
        Setup();        
    }

    void Update()
    {
        OnUpdateState();        
    }

    private void UpdateGun()
    {
        //stateText.text += gun.ReloadString;

        gunFireDelay += Time.deltaTime;

        float playerDir = player.transform.position.x > transform.position.x ? 1 : -1;
        gun.transform.localPosition = new Vector3(playerDir * 0.7f, 0, 0);

        if( player != null )
        {
            Vector2 dir = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;            

            if (playerInSight)
            {
                if (gunFireDelay >= 0.2f)
                {
                    EnemyBullet enemyBullet = GameObject.Instantiate(_enemySO.Bullet, gunTip.position, Quaternion.identity).GetComponent<EnemyBullet>();
                    enemyBullet.Fire(dir.normalized);
                    gunFireDelay = 0;
                }
            }
        }
    }

    private void OnEnterState(EnemyState state)
    {
        if (state == enemyState)
            return;

        OnLeaveState(enemyState);
        enemyState = state;

        switch (enemyState)
        {
            case EnemyState.Roaming:
                {                    
                    break;
                }
            case EnemyState.Attack:
                {
                    gunFireDelay = 0;
                    _findEnemyMark.SetActive(true);
                    _findWallMark.SetActive(false);
                    break;
                }
        }
    }

    private void OnLeaveState(EnemyState state)
    {
        switch (enemyState)
        {
            case EnemyState.Roaming:
                {
                    break;
                }
            case EnemyState.Attack:
                {
                    _findEnemyMark.SetActive(false);
                    break;
                }
        }
    }

    private void OnUpdateState()
    {
        hpText.text = _hp.ToString();
        stateText.text = enemyState.ToString();

        switch ( enemyState )
        {
            case EnemyState.Roaming:
                {
                    OnUpdateRoaming();
                    break;
                }
            case EnemyState.Attack: 
                {
                    OnUpdateAttack();
                    break;
                }
        }
    }

    private void OnUpdateRoaming()
    {
        Transform tr = transform;
        // ���� ���ʹ��� ��ġ�� ����
        Vector2 currentPosition = tr.position;
        Vector2 currentPosition2 = tr.position + new Vector3(0, -0.1f);
        // ���� ���Ⱚ ����
        float dir = _direction == Direction.Left ? -1f : 1f;

        // �÷��̾ �þ� �Ÿ� �ȿ� ����
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        playerInSight = playerDistance <= _sight;
        
        if (playerInSight)
        {
            float playerDir = player.transform.position.x > transform.position.x ? 1 : -1;
            RaycastHit2D hit = Physics2D.Raycast(currentPosition2, new Vector2(playerDir, 0), _sight, _wallLayer);
            if (hit.collider != null)
            {   // �þ� �ȿ� �ִµ� ���� ���� ����
                float wallDistance = Vector3.Distance(hit.collider.transform.position, transform.position);

                if( wallDistance < playerDistance ) 
                {
                    _findWallMark.SetActive(true);
                    return;
                }                
            }
            else
            {
                OnEnterState(EnemyState.Attack);
                return;
            }
        }

        _findWallMark.SetActive(false);

        //else
        //{
        RaycastHit2D hit2 = Physics2D.Raycast(currentPosition2, new Vector2(dir, 0), _wallSight, _wallLayer);
        if (hit2.collider != null)
        {
            dir = ChangeDirection();
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

    private void OnUpdateAttack()
    {
        Transform tr = transform;
        // ���� ���ʹ��� ��ġ�� ����
        Vector2 currentPosition = tr.position;
        Vector2 currentPosition2 = tr.position + new Vector3(0, -0.1f);
        // ���� ���Ⱚ ����
        float dir = _direction == Direction.Left ? -1f : 1f;

        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        // �÷��̾ �þ� ������ ����
        if (playerDistance > _sight)
        {
            OnEnterState(EnemyState.Roaming);
            return;
        }
        
        UpdateGun();
    }

    private float ChangeDirection()
    {
        _direction = _direction == Direction.Left ? Direction.Right : Direction.Left;
        return SetDirectionScale();
    }

    private float SetDirectionScale()
    {
        float dir = _direction == Direction.Left ? -1 : 1;
        transform.localScale = new Vector3(dir, 1, 1);
        return dir;
    }

    private void Setup()
    {   
        _hp = _enemySO.Enemy_HP;
        _directionMoveDistance = _enemySO.Enemy_RoamingRange;
        _moveSpeed = _enemySO.Enemy_MoveSpeed;

        _sight = _enemySO.Sight;
        _wallSight = _enemySO.WallSight;

        _findEnemyMark.SetActive(false);
        _findWallMark.SetActive(false);

        if(player == null )
        {
           player = GameObject.FindObjectOfType<PlayerController>();
        }

        Vector3 pos = transform.position;
        moveRange.x = pos.x - _directionMoveDistance;
        moveRange.y = pos.x + _directionMoveDistance;

        SetDirectionScale();
    }

    public void Damage (int amout)
    {
        if (_hp <= 0)
            return;

        _hp -= amout;
        if (_hp <= 0)
        {
            StartCoroutine(OnDie());
            Destroy(gameObject);
        }
    }    

    IEnumerator OnDie()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("enemy-die");

        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}
