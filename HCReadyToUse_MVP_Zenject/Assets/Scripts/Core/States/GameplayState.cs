using Core.UI;
using Core.Level;
using Core.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Core.PlayerModule;
using Zenject;

namespace Core.States
{
    public class GameplayState : BaseState<ApplicationStates>
    {
        public override ApplicationStates State => ApplicationStates.Gameplay;

        private IStateMachine<GameplayStates> _gameplayStateMachine;
        [Inject] private DiContainer _diContainer;

        public GameplayState()
        {

        }

        public override void Enter()
        {
            PrepareGameplayStateMachine();
            _gameplayStateMachine.SwitchToState(GameplayStates.Prepare);
        }

        public override void Exit()
        {

        }

        private void PrepareGameplayStateMachine()
        {
            _gameplayStateMachine = _diContainer.Resolve<IStateMachine<GameplayStates>>();
            var prepareState = _diContainer.Resolve<PrepareState>();
            var lobbyState = _diContainer.Resolve<LobbyState>();
            var gameState = _diContainer.Resolve<GameState>();
            _gameplayStateMachine.InitiateStateMachine(prepareState, lobbyState, gameState);
        }

    }

}