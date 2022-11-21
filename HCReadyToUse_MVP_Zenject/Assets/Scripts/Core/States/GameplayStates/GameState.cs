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

        private const string GAME_CAMERA_POINT_NAME = "Game";

        private IGameScreenPresenter _gameScreen;
        private CameraFollow _cameraFollow;
        private Transform _gameCameraPoint;

        public GameState(IGameScreenPresenter gameScreenPresenter, ICamerasManager camerasManager, CameraPointsHolder cameraPointsHolder)
        {
            _gameScreen = gameScreenPresenter;
            _gameCameraPoint = cameraPointsHolder.GetCameraTransform(GAME_CAMERA_POINT_NAME);
            var mainCamera = camerasManager.GetCamera(CameraLogic.CameraType.Main);
            mainCamera.TryGetComponent(out _cameraFollow);
        }

        public override void Enter()
        {
            _gameScreen.Init();
            _gameScreen.Show();

            _cameraFollow.ChangeOffset(_gameCameraPoint);
        }

        public override void Exit()
        {
            _gameScreen.Hide();
        }

    }
}