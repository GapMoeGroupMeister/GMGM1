using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float _speed = 3f;  // �ӵ�
    private float _normalSpeed = 3f;
    private float _runSpeed = 7f;
    private Rigidbody2D _rigid;  // Rigidbody �Լ�
    private float _jumpPower = 6f;  // ���� ����
    public bool isGround;
    

    [SerializeField]
    private LayerMask _whatIsGround;
    [SerializeField]
    private float _ray = 1f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>(); // Rigidbody�Լ��� Rigidbody2D �����ͼ� �ֱ�
       
    }

    void Update()
    {
        Sit();
        Run(); // �޸��� �����Ӹ��� ����
        Jump();  // ���� �����Ӹ��� ����
        Move();  // ������ �����Ӹ��� ����
    }

    private void Move()
    {
        float inputx = (Input.GetAxisRaw("Horizontal")); // inputx�� ������ �� �־��ֱ�

        _rigid.velocity = new Vector2(inputx * _speed , _rigid.velocity.y);
                                     // �ӵ�            
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
        

        if (Input.GetKeyDown(KeyCode.Space)) // ���� Ű �Է� ������ �۵�
        {
            RaycastHit2D check = Physics2D.Raycast(transform.position, Vector2.down, _ray, _whatIsGround);
           if(check.collider != null)
            {
                _rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse); // ���� ���� ����
                                                                               // ��� ������ ������ �ѹ� ��(Impulse)
            }

        }


    }
    


    
}
