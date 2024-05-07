using System;
using EntityManage;
using Unity.VisualScripting;
using UnityEngine;

public class ExplodeObject : EffectObject
{
    [SerializeField] private float _explodeRange;
    [SerializeField] private int _damage = 5;
    [SerializeField] private LayerMask _damageTargetLayer;

    public override void Play()
    {
        base.Play();
        Explode();
    }

    public void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _explodeRange, _damageTargetLayer);
        if (hits == null) return;

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out IDamageable health))
            {
                health.TakeDamage(_damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explodeRange);
    }
}
