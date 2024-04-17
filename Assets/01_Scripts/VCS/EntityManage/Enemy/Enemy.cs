using System;
using UnityEngine;

namespace EntityManage.Enemy
{
    public abstract class Enemy : Entity
    {
        public Animator AnimatorCompo { get; private set; }
        public bool CanStateChangeable { get; private set; }

        protected virtual void Awake()
        {
            AnimatorCompo = GetComponentInChildren<Animator>();
        }

        protected abstract void AttackPlayer();
    }
}