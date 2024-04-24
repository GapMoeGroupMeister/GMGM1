using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Jump,
    Sit,
    Dash,

}

public class PlayerController : MonoBehaviour
{
    public event Action<int, int> OnHealthChangedEvent;
    public Action<int, int> OnShootEvent; 
    [SerializeField]
    private PlayerState currentState;
    [SerializeField]
    private float _speed = 4f;  // ???
    [SerializeField]
    private float _normalSpeed = 4f;
    [SerializeField]
    private float _runSpeed = 8f;
    [SerializeField]
    private float _sitSpeed = 2f;
    [SerializeField]
    private float _jumpPower = 5f;  // ???? ????
    int currentHp = 100;
    int maxHp = 100;

    [SerializeField]
    private float inputx;
    private Vector2 mousePos;

    [SerializeField]
    private GameObject _gameOverUI;
    [SerializeField]
    private LayerMask _whatIsGround;
    [SerializeField]
    private float _ray = 1f;

    public bool isGround;

    private Rigidbody2D _rigid;  // Rigidbody ???
    private SpriteRenderer SpriteRenderer;
    private Animator _anim;
    private PlayerInput _playerInput;

    private Gun _currentGun;
    public Gun CurrentGun { get; private set; }


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>(); // Rigidbody????? Rigidbody2D ??????? ???
        SpriteRenderer = GetComponent<SpriteRenderer>();
        _currentGun = GetComponentInChildren<Gun>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerInput.OnMoveMentEvent += InputKey;

    }

    //private void OnDisable()
    //{
    //    _playerInput.OnMoveMentEvent -= InputKey;
    //}

    [ContextMenu("DebugRefreshHealth")]
    public void RefreshHealth()
    {
        OnHealthChangedEvent?.Invoke(currentHp, maxHp);
    }

    void Update()
    {
        
        CheckGround();
        CheckMove();
        CheckAnim();

        PlayerRoutine();

        Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            currentHp -= 10;
            OnHealthChangedEvent?.Invoke(currentHp, maxHp);
            CheckDie();
        }
    }

    private void CheckDie()
    {
        if (currentHp <= 0)
        {
            Destroy(gameObject);
            _gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void UseHeal(int amount)
    {
        currentHp += amount;
    }

    private void CheckAnim()
    {
        _anim.SetBool("PlayerWalk", inputx != 0 ? true : false);
    }

    private void CheckGround()
    {
        isGround = Physics2D.Raycast(transform.position, Vector2.down, _ray, _whatIsGround);
    }

    private void CheckMove()
    {
         // inputx?? ?????? ?? ??????
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void InputKey(float x, bool LeftShift, bool LeftControl,bool Space)
    {
        currentState = PlayerState.Idle;
        if (x != 0)
        {
            currentState = PlayerState.Walk;
            inputx = x;
        }


        if (LeftShift && isGround) 
        {
            if (currentState == PlayerState.Walk)
            {
                currentState = PlayerState.Run;
                _anim.SetBool("PlayerRun", true);
            }     
        }


        if (LeftControl) 
        {
            currentState = PlayerState.Sit;
            _anim.SetBool("PlayerSit", true);
        }
        


        if (Space)
        {
            if (isGround)
            {
                _rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            }
        }
    }
    

    private void Flip()
    {

        SpriteRenderer.flipX = transform.position.x > mousePos.x;
        
    }

    private void PlayerRoutine()
    {
        switch (currentState)
        {
            case PlayerState.Idle:

                break;

            case PlayerState.Walk:
                _speed = _normalSpeed;
                _rigid.velocity = new Vector2(inputx * _speed, _rigid.velocity.y);
                break;

            case PlayerState.Run:
                _speed = _runSpeed;
                _rigid.velocity = new Vector2(inputx * _speed, _rigid.velocity.y);

                break;

            case PlayerState.Sit:
                _speed = _sitSpeed;
                _rigid.velocity = new Vector2(inputx * _speed, _rigid.velocity.y);
                transform.Translate(Vector3.down * 0.5f * Time.deltaTime);
                break;

            //case PlayerState.UseHeal:
                
        }

    }

    
}
