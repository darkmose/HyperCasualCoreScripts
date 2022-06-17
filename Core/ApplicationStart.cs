using Configuration;
using Core.DISimple;
using Core.Events;
using Core.Gameplay;
using Core.PlayerModule;
using Core.Resourses;
using Core.States;
using Core.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ApplicationStart : MonoBehaviour
    {
        public GameConfiguration GameConfiguration => _gameConfiguration;

        [SerializeField] private GameConfiguration _gameConfiguration;
        [SerializeField] private ResourceHolder _resourceHolder;

        private SaveManager _saveManager;
        private IStateMachine<ApplicationStates> _stateMachine;

        void Awake()
        {
            ServiceLocator.Register(_gameConfiguration);
            ServiceLocator.Register(_resourceHolder);
        }

        private void Start()
        {
            PrepareStateteMachine();

            _stateMachine.SwitchToState(ApplicationStates.Loading);
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

        private void PrepareStateteMachine()
        {
            var gameScreen = UIManager.GetView<GameScreen>();
            var winWindow = UIManager.GetView<WinWindow>();
            var loseWindow = UIManager.GetView<LoseWindow>();
            var lobbyScreen = UIManager.GetView<LobbyScreen>();
            var loadingState = new LoadingState(_resourceHolder);
            var player = ServiceLocator.Resolve<Player>();
            _saveManager = new SaveManager(player);
            var levelController = ServiceLocator.Resolve<Core.Level.LevelController>();
            var gameplayState = new GameplayState(lobbyScreen, gameScreen, winWindow, player.LevelProgression, levelController, loseWindow);
            _stateMachine = new BaseStateMachine<ApplicationStates>(loadingState, gameplayState);
            ServiceLocator.Register(_stateMachine);
        } 
    }
}