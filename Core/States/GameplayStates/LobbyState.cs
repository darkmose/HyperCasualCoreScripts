using Core.PlayerModule;
using Core.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Events;
using Core.Level;
using Core.DISimple;

namespace Core.States
{
    public class LobbyState : BaseState<GameplayStates>
    {
        public override GameplayStates State => GameplayStates.Lobby;

        private LobbyScreen _lobbyScreen;
        private GameScreen _gameScreen;
        private LevelController _levelController;

        public LobbyState(LobbyScreen lobbyScreen, LevelController levelController, GameScreen gameScreen)
        {
            _lobbyScreen = lobbyScreen;
            _lobbyScreen.InitCallback(OnStartButtonHandler);
            _levelController = levelController;
            _gameScreen = gameScreen;
        }

        public override void Enter()
        {
            var lobbyCameraOffset = ServiceLocator.Resolve<Configuration.GameConfiguration>().LobbyCameraOffset;
            _levelController.FollowCamera.ChangeOffset(lobbyCameraOffset);
            _lobbyScreen.Show();
            _gameScreen.Show();
            _lobbyScreen.SetLevelNumber(_levelController.LevelProgression.CurrentLevel);
            _gameScreen.SetCurrentLevel(_levelController.LevelProgression.CurrentLevel);
        }

        public override void Exit()
        {
            _lobbyScreen.Hide();
        }

        private void OnStartButtonHandler()
        {
            EventAggregator.Post(this, new GameStartEvent());
            stateMachine.SwitchToState(GameplayStates.Game);
        }

    }
}