using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Resourses;
using Core.Gameplay;
using Core.PlayerModule;

namespace Core.Level
{
    public class LevelController
    {
        private LevelData _levelData;
        private PlayerData _playerData;
        private ResourceHolder _resourceHolder;
        private ILevelProgression _levelProgression;
        private CameraFollow _followCamera;
        
        public event System.Action<float> OnProgressChange;

        public ILevelProgression LevelProgression => _levelProgression;
        public LevelData LevelData => _levelData;
        public CameraFollow FollowCamera => _followCamera;
        public PlayerData PlayerData => _playerData;

        public LevelController(ILevelProgression progression, ResourceHolder resource)
        {
            _levelProgression = progression;
            _resourceHolder = resource;
        }

        private void ClearLevel() 
        {
            if (!System.Object.ReferenceEquals(_levelData, null))
            {
                _followCamera.SetTarget(null);
                GameObject.Destroy(_playerData.gameObject);
                GameObject.Destroy(_levelData.gameObject);
            }
        }

        private void PrepareLevel()
        {
            if (_resourceHolder.Levels.Count > 0)
            {
                _levelData = _resourceHolder.GetLevelRepeatly(_levelProgression.CurrentLevel);
                _levelData = Object.Instantiate(_levelData);
            }
        }

        public void CameraShakingOption(bool value) 
        {
            if (value)
            {
                FollowCamera.ShakingCameraOn();
            }
            else
            {
                FollowCamera.ShakingCameraOff();
            }
        }

        private void PreparePlayer()
        {
            var playerData = Core.DISimple.ServiceLocator.Resolve<Core.Resourses.ResourceHolder>().GetFirstPlayer();
            _playerData = _levelData.PlayerSpawner.SpawnPlayer(playerData.gameObject);
        }

        private void PrepareCamera() 
        {
            var camera = Camera.main;
            if (camera.TryGetComponent(out CameraFollow cameraFollow))
            {
                _followCamera = cameraFollow;
            }
            else
            {
                _followCamera = camera.gameObject.AddComponent<CameraFollow>();
            }
            _followCamera.SetTarget(_playerData.transform);
        }

        public void PrepareNextLevel()
        {
            ClearLevel();
            PrepareLevel();
            PreparePlayer();
            PrepareCamera();
        }
    }
}