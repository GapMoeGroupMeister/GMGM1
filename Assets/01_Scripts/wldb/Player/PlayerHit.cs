using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private Material _originalMaterial;
    [SerializeField]
    private Material _hitMaterial;
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalMaterial = _spriteRenderer.material;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
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

    


}
