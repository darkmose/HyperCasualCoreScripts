using Core.States;
using UnityEngine;


namespace Core.Enemy
{
    public class EnemyIdleState : BaseState<EnemyStates>
    {
        public override EnemyStates State => EnemyStates.Idle;

        private const string IdleTriggerName = "Idle";
        private Animator _animator;
        private EnemyData _enemyData;

        public EnemyIdleState(Animator animator, EnemyData enemyData)
        {
            _animator = animator;
            _enemyData = enemyData;
        }

        public void SwitchToDie() 
        {
            _animator.SetTrigger(IdleTriggerName);
            stateMachine.SwitchToState(EnemyStates.Die);
        }

        public override void Enter()
        {
            _enemyData.LifeSystem.OnEnemyDie += SwitchToDie;            
        }

        public override void Exit()
        {
            _animator.ResetTrigger(IdleTriggerName);
            _enemyData.LifeSystem.OnEnemyDie -= SwitchToDie;
        }
    }
}

