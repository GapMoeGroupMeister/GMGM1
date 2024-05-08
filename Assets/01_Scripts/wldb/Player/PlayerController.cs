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
    Sliding,
    Dash,

}

public class PlayerController : MonoBehaviour
{
    public event Action<int, int> OnHealthChangedEvent;
    public Action<int, int> OnShootEvent;
    public Action<bool> _AnimaWalk;
    public Action<bool> _AnimaRun;
    public Action<bool> _AnimaJump;
    public Action<bool> _AnimaSliding;
    
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
    [SerializeField]
    private float _slidingPower = 3f;
    float jumpPadPower = 30f;
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
    private bool checkSliding = false;

    private Rigidbody2D _rigid;  // Rigidbody ???
    private SpriteRenderer SpriteRenderer;
    private PlayerInput _playerInput;

    private Gun _currentGun;
    public Gun CurrentGun { get; private set; }

    JumpPad _jumpPad;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>(); // Rigidbody????? Rigidbody2D ??????? ???
        SpriteRenderer = GetComponent<SpriteRenderer>();
        _currentGun = GetComponentInChildren<Gun>();
        _jumpPad = FindAnyObjectByType<JumpPad>();

    }

    private void Start()
    {
        _playerInput.OnMovementEvent += Move;
        _playerInput.OnJumpEvent += Jump;
        _playerInput.OnSitEvent += Sliding;
        _playerInput.OnRunEvent += Run;
        _jumpPad._ChackJumpPad += PressedJumpPad;

    }

    private void PressedJumpPad()
    {
        _rigid.velocity = Vector2.up *  jumpPadPower;
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
        Sliding();
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
        _AnimaWalk?.Invoke(inputx != 0);

        _AnimaRun?.Invoke(inputx != 0 && currentState == PlayerState.Run);

        _AnimaJump?.Invoke(!isGround);

        _AnimaSliding?.Invoke(checkSliding);
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

    private void Move(float x)
    {
        inputx = x;
        if (x != 0)
        {
            currentState = PlayerState.Walk;
        }
    }

    private void Run(bool LeftShift)
    {
        if (LeftShift && isGround)
        {
            if (currentState == PlayerState.Walk)
            {
                currentState = PlayerState.Run;
            }
        }
    }

    private void Sliding(bool LeftControl)
    {

        if (checkSliding || !isGround)
        {
            return;
        }
        _rigid.AddForce(new Vector2(transform.position.x > mousePos.x ? -1 : 1, 0) * _slidingPower, ForceMode2D.Impulse);
        checkSliding = true;
        currentState = PlayerState.Sliding;
        StartCoroutine("CheckSliding");
    }

    IEnumerator CheckSliding()
    {
        yield return new WaitForSeconds(1);
        checkSliding = false;
        currentState = PlayerState.Walk;
    }
    

    private void Jump(bool Space)
    {
        if (Space)
        {
            if (isGround)
            {
                _rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    private void Sliding()
    {
        
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
                if (isGround) _rigid.velocity = Vector2.zero;
                break;

            case PlayerState.Walk:
                _AnimaSliding?.Invoke(false);
                _speed = _normalSpeed;
                _rigid.velocity = new Vector2(inputx * _speed, _rigid.velocity.y);
                break;

            case PlayerState.Run:
                _AnimaWalk?.Invoke(false);
                _speed = _runSpeed;
                _rigid.velocity = new Vector2(inputx * _speed, _rigid.velocity.y);

                break;

            case PlayerState.Sliding:
                _AnimaWalk?.Invoke(false);
                _AnimaRun?.Invoke(false);
                break;


                //case PlayerState.UseHeal:

        }

    }

    
}
