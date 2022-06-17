using Core.States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Enemy
{
    public enum EnemyStates
    {
        Idle,
        Die,
    }

    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private GameObject _enemyBody;
        private IStateMachine<EnemyStates> _stateMachine;

        private void Awake()
        {
            PrepareStateMachine();
        }

        private void PrepareStateMachine() 
        {
            var idleState = new EnemyIdleState(_animator, _enemyData);
            var dieState = new EnemyDieState(_animator, _enemyData);
            _stateMachine = new BaseStateMachine<EnemyStates>(idleState, dieState);                 
            _stateMachine.SwitchToState(EnemyStates.Idle);
        }
    }
}

