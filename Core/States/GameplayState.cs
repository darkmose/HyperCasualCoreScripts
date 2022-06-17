using Core.UI;
using Core.Level;
using Core.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Core.Gameplay;
using Core.PlayerModule;

namespace Core.States
{
    public class GameplayState : BaseState<ApplicationStates>
    {
        public override ApplicationStates State => ApplicationStates.Gameplay;

        private IStateMachine<GameplayStates> _gameplayStateMachine;

        private GameScreen _gameScreen;

        private LobbyScreen _lobbyScreen;

        private WinWindow _winWindow;

        private LoseWindow _loseWindow;

        private ILevelProgression _levelProgression;

        private LevelController _levelController;

        public GameplayState(LobbyScreen lobbyScreen, GameScreen gameScreen, WinWindow winWindow, ILevelProgression levelProgression, LevelController levelController, LoseWindow loseWindow)
        {
            _gameScreen = gameScreen;
            _lobbyScreen = lobbyScreen;
            _winWindow = winWindow;
            _loseWindow = loseWindow;
            _levelController = levelController;
            _levelProgression = levelProgression;

            PrepareGameplayStateMachine();
        }

        public override void Enter()
        {
            _gameplayStateMachine.SwitchToState(GameplayStates.Prepare);
        }

        public override void Exit()
        {

        }

        private void PrepareGameplayStateMachine()
        {
            var prepareState = new PrepareState(_levelController);
            var lobbyState = new LobbyState(_lobbyScreen, _levelController, _gameScreen);
            var gameState = new GameState(_gameScreen, _levelController);
            var finishState = new FinishState(_winWindow, _levelProgression, _levelController, _gameScreen);
            var loseState = new LoseState(_loseWindow);
            _gameplayStateMachine = new BaseStateMachine<GameplayStates>(prepareState, lobbyState, gameState, finishState, loseState);
        }

    }

}