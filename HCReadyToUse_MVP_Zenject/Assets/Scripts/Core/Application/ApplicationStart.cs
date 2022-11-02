using Configuration;
using Core.DISimple;
using Core.Events;
using Core.PlayerModule;
using Core.Resourses;
using Core.States;
using Core.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{
    public class ApplicationStart : MonoBehaviour
    {
        private IStateMachine<ApplicationStates> _stateMachine;
        private DiContainer _diContainer;

        void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
            _diContainer = ServiceLocator.Resolve<DiContainer>();
            PrepareApplicationStateMachine();
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                EventAggregator.Post(this, new StorageEvent());
            }
        }

        private void OnApplicationQuit()
        {
            EventAggregator.Post(this, new StorageEvent());
        }

        private void PrepareApplicationStateMachine()
        {            
            var loadingState = _diContainer.Resolve<LoadingState>();
            var gameplayState = _diContainer.Resolve<GameplayState>();
            _stateMachine = _diContainer.Resolve<IStateMachine<ApplicationStates>>();
            _stateMachine.InitiateStateMachine(loadingState, gameplayState);
            _stateMachine.SwitchToState(ApplicationStates.Loading);
        }
    }
}