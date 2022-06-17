using Core.States;
using UnityEngine;


namespace Core.Enemy
{
    public class EnemyDieState : BaseState<EnemyStates>
    {
        public override EnemyStates State => EnemyStates.Die;

        private const string DieTriggerName = "Die";
        private Animator _animator;
        private EnemyData _enemyData;

        public EnemyDieState(Animator animator, EnemyData enemyData)
        {
            _enemyData = enemyData;
            _animator = animator;
        }

        public override void Enter()
        {
            _animator.SetTrigger(DieTriggerName);
            _enemyData.GetComponent<Collider>().enabled = false;      
        }

        public override void Exit()
        {
        }
    }

}

