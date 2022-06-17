using Core.Events;
using Core.Gameplay;
using Core.PlayerModule;
using Core.UI;
using Core.DISimple;
using Core.Level;
using Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Core.States
{
    public class FinishState : BaseState<GameplayStates>
    {
        public override GameplayStates State => GameplayStates.Finish;

        private WinWindow _winWindow;

        private LevelController _levelController;

        private ILevelProgression _levelProgression;

        private GameScreen _gameScreen;


        public FinishState(WinWindow winWindow, ILevelProgression levelProgression, LevelController levelController, GameScreen gameScreen)
        {
            _winWindow = winWindow;
            _winWindow.InitCallback(OnNextButtonHandler);
            _levelProgression = levelProgression;
            _levelController = levelController;
            _gameScreen = gameScreen;
        }

        public override void Enter()
        {
            var finishCameraOffset = ServiceLocator.Resolve<GameConfiguration>().FinishCameraOffset;
            _levelController.FollowCamera.ChangeOffset(finishCameraOffset);
        }

        public override void Exit()
        {
            _winWindow.Hide();
        }

        private void OnNextButtonHandler()
        {
            stateMachine.SwitchToState(GameplayStates.Prepare);
        }


        private void OnBossDefeated() //Точка перехода на новый уровень (Событие конца уровня)
        {
            _winWindow.SetWinLevel(_levelProgression.CurrentLevel);
            _levelProgression.SetLevelNumber(_levelProgression.CurrentLevel + 1);
            EventAggregator.Post(this, new StorageEvent());
            _winWindow.Show();
        }
    }
}