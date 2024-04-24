using System;

namespace EntityManage.Enemy
{
    public class TestEnemy : Enemy
    {
        public EnemyStateMachine<TestEnemyStateEnum> StateMachine;

        protected override void Awake()
        {
            base.Awake();
            StateMachine = new EnemyStateMachine<TestEnemyStateEnum>();
        }

        private void Update()
        {
            StateMachine.CurrentState.UpdateState();
        }


        public override void Die()
        {
            // 에너미 뒤짐
        }

        protected override void AttackPlayer()
        {
            
            
        }
    }
}