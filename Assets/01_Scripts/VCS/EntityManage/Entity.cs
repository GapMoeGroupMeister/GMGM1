using System;
using UnityEngine;

namespace EntityManage
{
    
    public abstract class Entity : MonoBehaviour, IDamageable
    {
        public event Action OnDamagedEvent;
        
        protected Status _status;
        public Status Status => _status;

        public bool IsDie => _status.hp <= 0;

        public virtual void TakeDamage(int amount)
        {
            if (_status.isResist) return;

            _status.hp -= amount;
            ClampHealth();
            CheckDie();
        }

        public virtual void RestoreHealth(int amount)
        {
            _status.hp += amount;
            ClampHealth();
        }

        public void CheckDie()
        {
            if (IsDie)
            {
                Die();
            }
        }

        protected void ClampHealth()
        {
            _status.hp = Mathf.Clamp(_status.hp, 0, _status.MaxHp);
        }

        public abstract void Die();
    }

}