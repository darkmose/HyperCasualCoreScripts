using Core.DISimple;
using Core.Events;
using Core.Gameplay;
using Core.UI;
using Core.Level;
using Core.Resourses;
using Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.States
{
    public class GameState : BaseState<GameplayStates>
    {
        public override GameplayStates State => GameplayStates.Game;

        private GameScreen _gameScreen;
        private LevelController _levelController;

        public GameState(GameScreen gameScreen, Core.Level.LevelController levelController)
        {
            _gameScreen = gameScreen;
            _levelController = levelController;
        }

        public override void Enter()
        {
            var gameCameraOffset = ServiceLocator.Resolve<GameConfiguration>().GameCameraOffset;
            _levelController.FollowCamera.ChangeOffset(gameCameraOffset);
            _levelController.LevelData.LevelFinishTrigger.OnLevelFinished += OnGameFinishHandler;
        }

        public override void Exit()
        {
            _levelController.LevelData.LevelFinishTrigger.OnLevelFinished -= OnGameFinishHandler;
        }

        private void OnGameFinishHandler()
        {
            stateMachine.SwitchToState(GameplayStates.Finish);
        }

        private void OnGameLoseHandler() 
        {
            stateMachine.SwitchToState(GameplayStates.Lose);
        }

    }
}