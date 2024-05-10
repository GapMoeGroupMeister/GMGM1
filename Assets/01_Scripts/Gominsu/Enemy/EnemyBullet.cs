using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _lifeTime = 6;

    private Rigidbody2D _rigid;
    [SerializeField] private EffectObject _destoryParticle; 
    private Vector2 _direction;
    
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 dir)
    {
        _direction = dir;
        _rigid.velocity = dir.normalized * _speed;
        transform.right = dir;
        StartCoroutine(BulletCoroutine());
    }

    private IEnumerator BulletCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(_lifeTime, _lifeTime+1f));
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Instantiate(_destoryParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopAllCoroutines();
        DestroyBullet();
        DestroyBullet();
    }
}