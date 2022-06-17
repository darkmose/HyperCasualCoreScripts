using Core.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/Game Config")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private int _playerCoinsAmount = 0;
        [SerializeField] private float _playerSpeed = 1f;
        [SerializeField] private Vector3 _lobbyCameraOffset;
        [SerializeField] private Vector3 _gameCameraOffset;
        [SerializeField] private Vector3 _finishCameraOffset;
        [SerializeField] private float _cameraSensitive = 0.5f;

        public int PlayerCoinsAmoint => _playerCoinsAmount;
        public float CameraSensitive => _cameraSensitive;
        public float PlayerSpeed => _playerSpeed;
        public Vector3 LobbyCameraOffset => _lobbyCameraOffset;
        public Vector3 GameCameraOffset => _gameCameraOffset;
        public Vector3 FinishCameraOffset => _finishCameraOffset;
    }
}