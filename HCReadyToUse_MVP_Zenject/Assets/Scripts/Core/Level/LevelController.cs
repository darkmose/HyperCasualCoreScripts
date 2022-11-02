using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Resourses;
using Core.PlayerModule;
using Core.CameraLogic;
using Core.GameLogic;

namespace Core.Level
{
    public interface ILevelController
    {
        void PrepareNextLevel();
    }

    public class LevelController : ILevelController
    {
        private LevelData _levelData;
        private ResourceHolder _resourceHolder;
        private ILevelProgression _levelProgression;
        private PlayerData _playerdata;
        private CameraFollow _cameraFollow;

        public LevelData LevelData => _levelData;

        public LevelController(ResourceHolder resourceHolder, ILevelProgression levelProgression, PlayerData playerdata, CameraFollow cameraFollow)
        {
            _resourceHolder = resourceHolder;
            _levelProgression = levelProgression;
            _playerdata = playerdata;
            _cameraFollow = cameraFollow;
        }

        private void ClearLevel() 
        {
            if (!System.Object.ReferenceEquals(_levelData, null))
            {
                GameObject.Destroy(_levelData.gameObject);
            }
        }

        private void PrepareLevel()
        {
            if (_resourceHolder.Levels.Count > 0)
            {
                _levelData = _resourceHolder.GetLevelRepeatly(_levelProgression.CurrentLevel.Value);
                _levelData = Object.Instantiate(_levelData);
                _playerdata.transform.position = _levelData.PlayerStartPoint.position;
                _playerdata.transform.rotation = _levelData.PlayerStartPoint.rotation;
            }
        }

        private void PrepareCamera()
        {
            _cameraFollow.SetTarget(_playerdata.transform);
        }

        public void PrepareNextLevel()
        {
            ClearLevel();
            PrepareLevel();
            PrepareCamera();
        }
    }
}