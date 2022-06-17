using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Core.States
{
    public interface IStateMachine<T>
    {
        IState<T> Current { get; }
        void SwitchToState(T state);
        void SwitchToStateDelayed(T state, float delay);
    }

    public class BaseStateMachine<T> : IStateMachine<T>
    {
        private Dictionary<T, IState<T>> _states = new Dictionary<T, IState<T>>();

        private IState<T> _current;
        public IState<T> Current => _current;
        protected IStateMachine<T> _stateMachine;

        public BaseStateMachine(params IState<T>[] states)
        {
            foreach (var state in states)
            {
                _states[state.State] = state;
                state.stateMachine = this;
            }
            _stateMachine = this;
        }

        public void SwitchToStateDelayed(T state, float delay)
        {
            DOTween.Sequence().AppendInterval(delay).OnComplete(()=> { SwitchToState(state); });
        }

        public void SwitchToState(T state)
        {
            var nextState = _states[state];
            _current?.Exit();
            _current = nextState;
            _current.Prepare();
            _current.Enter();
        }
    }
}