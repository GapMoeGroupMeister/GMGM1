﻿using System;
using UnityEngine;

namespace EntityManage.Enemy
{
    public abstract class EnemyState<T> where T : Enum
    {
        protected EnemyStateMachine<T> _stateMachine;
        protected Enemy _enemyBase;
        protected bool _endTriggerCalled;
        protected int _animBoolParam;

        public EnemyState(Enemy enemyBase, EnemyStateMachine<T> stateMachine, string animBoolName)
        {
            _enemyBase = enemyBase;
            _stateMachine = stateMachine;
            _animBoolParam = Animator.StringToHash(animBoolName);;
        
        }
        
        public virtual void Enter()
        {
        
        
            _endTriggerCalled = false;
            _enemyBase.AnimatorCompo.SetBool(_animBoolParam, true);
        
        }
        public virtual void UpdateState()
        {
        
        
        }

        public virtual void Exit()
        {
            _enemyBase.AnimatorCompo.SetBool(_animBoolParam, false);

        }

        public void AnimationFinishTrigger()
        {
            _endTriggerCalled = true;
        }
        

        public virtual void CustomTrigger()
        {
            Debug.Log("CustomTrigger : Triggered");
        }
    }
}