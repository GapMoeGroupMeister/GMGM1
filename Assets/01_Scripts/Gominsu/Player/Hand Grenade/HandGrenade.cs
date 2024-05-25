using System.Collections;
using System.Collections.Generic;
using EntityManage;
using UnityEngine;

public class HandGrenade : MonoBehaviour
{
    private int damage;
    private float speed;

    [SerializeField] GameObject bulletEffect;
    [SerializeField] GameObject _hitEffect;

    bool _bulletEffect;
    bool _checkBulletEffect = true;
    GameObject _bulletEffect_;

    private Vector3 gunTipPosition;
    private float destroyDistance = 10;

    public Vector3 Direction;//�Ѿ� ����

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void SetDefault(float speed, float destroyDistance, int damage)
    {
        this.speed = speed;
        this.destroyDistance = destroyDistance;
        this.damage = damage;
    }



    public void Fire(Vector2 dir)
    {
        transform.right = dir;
        Direction = dir;
        gunTipPosition = transform.position;//�� ����� �ڽ��� ��ġ = �ѱ��� ��ġ 
        rigid.AddForce(dir * speed, ForceMode2D.Force);
        StartCoroutine(BoomTimer());
    }

    IEnumerator BoomTimer()
    {
        yield return new WaitForSeconds(2);
        Boom();
    }

    private void Boom()
    {
        Destroy(gameObject);
        /*�̰����� ������ ������ ��Ŭ�� ������
        ��� �繰�� ������ �ͼ� ���� �������� �Դ�
        ������Ʈ�鸸 �￩�ͼ� �������� �ش� + ���� ����Ʈ*/
    }

    private void Update()
    {
        //transform.position += Direction * speed * Time.deltaTime;

        //if (Vector2.Distance(gunTipPosition, transform.position) > destroyDistance)//���� Vector2.Distance�� destroyDistance���� ũ�ٸ� �Ѿ��� ����
        //{                                                                             //   ����� transform.position - guntip(���� �̵��� �Ÿ�)�̴�
        //    Destroy(gameObject);
        //}
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

    //        GameObject effect = Instantiate(_hitEffect);
    //        effect.transform.position = transform.position;
    //        effect.transform.localScale = new Vector3(enemy.transform.position.x > transform.position.x ? 1 : -1, 1, 1);

    //        effect.GetComponent<ParticleSystem>().Play(true);

    //        enemy.Damage(damage);
    //    }

    //    if (collision.transform.CompareTag("Object"))
    //    {
    //        IDamageable target = collision.gameObject.GetComponent<IDamageable>();
    //        target.TakeDamage(damage);
    //    }

    //    Destroy(gameObject);
    //    _bulletEffect_ = Instantiate(bulletEffect);
    //    _bulletEffect_.transform.position = transform.position;
    //}
}
