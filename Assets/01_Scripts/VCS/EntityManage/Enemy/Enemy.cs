using UnityEngine;

namespace EntityManage.Enemy
{
    public abstract class Enemy : Entity
    {
        
        public Animator AnimatorCompo { get; private set; }

        public bool CanStateChangeable { get; private set; }
        
        
        
        
    }
}