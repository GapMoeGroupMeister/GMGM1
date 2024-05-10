using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private Material _originalMaterial;
    [SerializeField]
    private Material _hitMaterial;
    private SpriteRenderer _spriteRenderer;
    PlayerWeaponManager _weaponManager;
    [SerializeField] private AudioClip _hitSound;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalMaterial = _spriteRenderer.material;
        _weaponManager = GetComponent<PlayerWeaponManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            StartCoroutine(Hit());
            _weaponManager.audioSource.clip = _hitSound;
            _weaponManager.audioSource.PlayOneShot(_weaponManager.audioSource.clip);
            _weaponManager.audioSource.clip = _weaponManager._gun.gunSound;
        }
    }

    IEnumerator Hit()
    {
        _spriteRenderer.material = _hitMaterial;
        yield return new WaitForSeconds(0.05f);
        _spriteRenderer.material = _originalMaterial;
        
    }

    


}
