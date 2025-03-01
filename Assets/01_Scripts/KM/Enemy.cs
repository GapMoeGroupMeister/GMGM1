using System.Collections;
using UnityEngine;
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

    [SerializeField] private EnemySO _enemySO;

    [SerializeField] private float _sight = 1;
    [SerializeField] private float _wallSight = 1;

    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _wallLayer;

    [SerializeField] private GameObject _findEnemyMark;
    [SerializeField] private GameObject _findWallMark;

    [SerializeField] private Transform playerTrm;
    [SerializeField] private Transform gunTip;

    [SerializeField] private Material _hitMaterial;
    
    private Material _originalMaterial;
    private SpriteRenderer _spriteRenderer;
    private Animator animator;


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
        if (_hp <= 0)
            return;

        OnUpdateState();        
    }

    private void UpdateGun()
    {
        gunFireDelay += Time.deltaTime;

        float playerDir = playerTrm.transform.position.x > transform.position.x ? 1 : -1;
        
        if( playerTrm != null )
        {
            Vector2 dir = ((Vector2)playerTrm.position - (Vector2)transform.position).normalized;            

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
                    animator.SetBool("isWalk", false);
                    _findEnemyMark.SetActive(false);
                    break;
                }
        }
    }

    private void OnUpdateState()
    {
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
        float playerDistance = Vector3.Distance(playerTrm.position, transform.position);
        playerInSight = playerDistance <= _sight;
        
        if (playerInSight)
        {
            float playerDir = playerTrm.position.x > transform.position.x ? 1 : -1;
            RaycastHit2D hit = Physics2D.Raycast(currentPosition2, new Vector2(playerDir, 0), _sight, _wallLayer);
            if (hit.collider != null)
            {   // �þ� �ȿ� �ִµ� ���� ���� ����
                float wallDistance = Vector3.Distance(hit.collider.transform.position, transform.position);

                if( wallDistance < playerDistance ) 
                {
                    _findWallMark.SetActive(true);
                    animator.SetBool("isWalk", false);
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

        animator.SetBool("isWalk", true);

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
        animator.SetBool("isWalk", false);

        UpdateDirection();

        Vector2 currentPosition = transform.position;
        Vector2 currentPosition2 = transform.position + new Vector3(0, -0.1f);
        float dir = _direction == Direction.Left ? -1f : 1f;

        float playerDistance = Vector3.Distance(playerTrm.position, transform.position);
        if (playerDistance > _sight)
        {
            OnEnterState(EnemyState.Roaming);
            return;
        }
        
        UpdateGun();
    }

    private float UpdateDirection()
    {
        _direction = transform.position.x >= playerTrm.position.x ? Direction.Left : Direction.Right;
        return SetDirectionScale();
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

        if(playerTrm == null )
        {
            playerTrm = GameManager.Instance.playerController.transform;
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalMaterial = _spriteRenderer.material;

        animator = GetComponent<Animator>();

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
            OnDie();
        }
        else
        {
            StartCoroutine(Hit());
        }
    }

    IEnumerator Hit()
    {
        _spriteRenderer.material = _hitMaterial;
        yield return new WaitForSeconds(0.05f);
        _spriteRenderer.material = _originalMaterial;
    }

    void OnDie()
    {
        _findWallMark.SetActive(false);
        _findEnemyMark.SetActive(false);

        animator.Play("enemy-die");
        GameManager.Instance.AddKillCount();
        EnemyManager.Instance.DeleteEnemy(this);
        //yield return new WaitForSeconds(3f);
        
    }
}
