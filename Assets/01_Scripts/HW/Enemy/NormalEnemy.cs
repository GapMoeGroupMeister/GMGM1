using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityManage;
using EntityManage.Enemy;
using System;

public enum NormalEnemyState
{
    Idle,
    Patrol,
    Die
}

public class NormalEnemy : EntityManage.Enemy.Enemy
{
    public EnemyStateMachine<NormalEnemyState> StateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine<NormalEnemyState>();

        foreach (NormalEnemyState stateEnum in Enum.GetValues(typeof(NormalEnemyState)))
        {
            string typeName = stateEnum.ToString();
            print(stateEnum);
            Type t = Type.GetType($"NormalEnemy{typeName}State");
            try
            {
                var enemyState = Activator.CreateInstance(t, this, StateMachine, typeName)
                                    as EnemyState<NormalEnemyState>;
                StateMachine.AddState(stateEnum, enemyState);
                Debug.Log(enemyState == null);
            }
            catch (Exception ex)
            {
                Debug.LogError($"NormalEnemy : no state [ {typeName} ]");
                Debug.LogError(ex);
            }
        }

    }

    private void Start()
    {
        StateMachine.Initialize(NormalEnemyState.Patrol, this);
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }

    public override void Die()
    {
    }

    protected override void AttackPlayer()
    {
    }
}
