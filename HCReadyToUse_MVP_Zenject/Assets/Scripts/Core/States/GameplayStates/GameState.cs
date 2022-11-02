using Core.UI;
using Core.MVP;
using Core.Level;
using Core.CameraLogic;
using UnityEngine;

namespace Core.States
{
    public class GameState : BaseState<GameplayStates>
    {
        public override GameplayStates State => GameplayStates.Game;

        private const string GameCameraPointName = "Game";
        private IGameScreenPresenter _gameScreen;

        public GameState(ILevelController levelController, IGameScreenPresenter gameScreenPresenter)
        {
            _gameScreen = gameScreenPresenter;
        }

        public override void Enter()
        {
            _gameScreen.Init();
            _gameScreen.Show();


        }

        public override void Exit()
        {
            _gameScreen.Hide();
        }

    }
}