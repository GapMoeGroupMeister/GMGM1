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

public class test : MonoBehaviour
{
    [SerializeField]
    private PlayerState currentState;
    [SerializeField]
    private float _speed = 4f;  // 속도
    [SerializeField]
    private float _normalSpeed = 4f;
    [SerializeField]
    private float _runSpeed = 8f;
    [SerializeField]
    private float _sitSpeed = 2f;
    [SerializeField]
    private float _jumpPower = 5f;  // 점프 높이
    float currentHp = 100f;
    float maxHp = 100f;

    [SerializeField]
    private float inputx;
    private Vector2 mousePos;

    [SerializeField]
    GameObject[] gunPrefab;
    GameObject gun1, gun2, gun3;
    [SerializeField]
    Slider hpBar;


    [SerializeField]
    private LayerMask _whatIsGround;
    [SerializeField]
    private float _ray = 1f;

    public bool isGround;

    private Rigidbody2D _rigid;  // Rigidbody 함수
    private SpriteRenderer SpriteRenderer;


    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>(); // Rigidbody함수에 Rigidbody2D 가져와서 넣기
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        hpBar.value = currentHp / maxHp;
     
    }

    void Update()
    {
        HandleHp();

        InputKey();
        CheckGround();
        CheckMove();

        PlayerRoutine();

        Flip();

        Gunswap();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            currentHp -= 10;
        }
    }

    private void HandleHp()
    {
        hpBar.value = currentHp / maxHp;
        if (currentHp <= 0)
        {
            Destroy(gameObject);
            
        }
        
    }

    //private void UseHeal()
    //{
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        currentHp += 10;
    //    }
    //}

    private void CheckGround()
    {
        isGround = Physics2D.Raycast(transform.position, Vector2.down, _ray, _whatIsGround);
    }

    private void CheckMove()
    {
        inputx = (Input.GetAxisRaw("Horizontal")); // inputx에 움직임 값 넣어주기
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void InputKey()
    {
        currentState = PlayerState.Idle;
        if (inputx != 0)
        {
            currentState = PlayerState.Walk;
        }

        if (Input.GetKey(KeyCode.LeftShift)) // 뛰기
        {
            if (currentState == PlayerState.Walk)
            {
                currentState = PlayerState.Run;
            }
            
        }

        if (Input.GetKey(KeyCode.LeftControl)) // 앉기
        {
            currentState = PlayerState.Sit;

        }

        if (Input.GetKeyDown(KeyCode.Space)) // 점프 키 입력 받으면 작동
        {
            if (isGround)
            {
            _rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);

            }
        }

        //if (Input.GetKeyDown(KeyCode.C))
        //{
            
        //}

        
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

    void Gunswap()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(gun1);
            gun1 = Instantiate(gunPrefab[0],gameObject.transform);
            gun1.transform.position = transform.position;
            Destroy(gun2);
            Destroy(gun3);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(gun2);
            gun2 = Instantiate(gunPrefab[1], gameObject.transform);
            gun2.transform.position = transform.position;
            Destroy(gun1);
            Destroy(gun3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(gun3);
            gun3 = Instantiate(gunPrefab[2], gameObject.transform);
            gun3.transform.position = transform.position;
            Destroy(gun1);
            Destroy(gun2);
        }



    }
}
