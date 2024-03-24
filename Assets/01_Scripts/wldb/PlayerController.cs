using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float _speed = 3f;  // 속도
    private float _normalSpeed = 3f;
    private float _runSpeed = 7f;
    private Rigidbody2D _rigid;  // Rigidbody 함수
    private float _jumpPower = 6f;  // 점프 높이
    public bool isGround;
    

    [SerializeField]
    private LayerMask _whatIsGround;
    [SerializeField]
    private float _ray = 1f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>(); // Rigidbody함수에 Rigidbody2D 가져와서 넣기
       
    }

    void Update()
    {
        Sit();
        Run(); // 달리기 프레임마다 실행
        Jump();  // 점프 프레임마다 실행
        Move();  // 움직임 프레임마다 실행
    }

    private void Move()
    {
        float inputx = (Input.GetAxisRaw("Horizontal")); // inputx에 움직임 값 넣어주기

        _rigid.velocity = new Vector2(inputx * _speed , _rigid.velocity.y);
                                     // 속도            
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _runSpeed;
        }
        else
        {
            _speed = _normalSpeed;
        }
    }

    private void Sit()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * 0.5f * Time.deltaTime);
        }
        
    }

    private void Jump()
    {
        

        if (Input.GetKeyDown(KeyCode.Space)) // 점프 키 입력 받으면 작동
        {
            RaycastHit2D check = Physics2D.Raycast(transform.position, Vector2.down, _ray, _whatIsGround);
           if(check.collider != null)
            {
                _rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse); // 점프 높이 조정
                                                                               // 즉시 점프값 높여줌 한번 띡(Impulse)
            }

        }


    }
    


    
}
