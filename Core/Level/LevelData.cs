using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Level
{
    public class LevelData : MonoBehaviour
    {
        public int LevelNumber => _levelNumber;
        public PlayerSpawner PlayerSpawner => _playerSpawner;
        public Core.Gameplay.LevelFinishTrigger LevelFinishTrigger => _finishTrigger;

        [SerializeField] private int _levelNumber;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private Core.Gameplay.LevelFinishTrigger _finishTrigger;
    }
}