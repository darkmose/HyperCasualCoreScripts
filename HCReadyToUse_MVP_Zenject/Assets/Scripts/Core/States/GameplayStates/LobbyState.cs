using Core.PlayerModule;
using Core.MVP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Events;
using Core.Level;
using Core.CameraLogic;
using Core.DISimple;

namespace Core.States
{
    public class LobbyState : BaseState<GameplayStates>
    {
        public override GameplayStates State => GameplayStates.Lobby;

        private const string LOBBY_CAMERA_POINT_NAME = "Lobby";

        private ILobbyScreenPresenter _lobbyScreenPresenter;
        private CameraFollow _cameraFollow;
        private Transform _lobbyCameraPoint;

        public LobbyState(ILobbyScreenPresenter lobbyScreenPresenter, CameraPointsHolder cameraPointsHolder, ICamerasManager camerasManager)
        {
            _lobbyScreenPresenter = lobbyScreenPresenter;
            _lobbyCameraPoint = cameraPointsHolder.GetCameraTransform(LOBBY_CAMERA_POINT_NAME);
            var mainCamera = camerasManager.GetCamera(CameraLogic.CameraType.Main);
            mainCamera.TryGetComponent(out _cameraFollow);
        }

        public override void Enter()
        {
            _lobbyScreenPresenter.Init();
            _lobbyScreenPresenter.Show();

            _cameraFollow.ChangeOffset(_lobbyCameraPoint);
        }

        public override void Exit()
        {
            _lobbyScreenPresenter.Hide();
        }
    }
}