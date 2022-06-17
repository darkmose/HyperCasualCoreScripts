using Core.Level;
using Core.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Resourses
{
    [CreateAssetMenu(fileName = "ResourceHolder", menuName = "ScriptableObjects/Resource Holder")]
    public class ResourceHolder : ScriptableObject
    {
        public List<LevelData> Levels => _levels;
        public List<PlayerData> Players => _players;

        public List<GameObject> Prefabs => _prefabs;

        [SerializeField] private List<LevelData> _levels = new List<LevelData>();
        [SerializeField] private List<PlayerData> _players = new List<PlayerData>();
        [SerializeField] private List<GameObject> _prefabs = new List<GameObject>();

        public LevelData GetLevel(int levelNumber)
        {
            var result = _levels.Find(levelData => levelData.LevelNumber == levelNumber);

            return result;
        }

        public LevelData GetLevelRepeatly(int levelNumber) 
        {
            LevelData result;
            if (levelNumber <= Levels.Count)
            {
                result = GetLevel(levelNumber);
            }
            else
            {
                int repeatCount = levelNumber / Levels.Count;
                int levelOffset = levelNumber - (repeatCount * Levels.Count);
                if (levelOffset == 0)
                {
                    result = GetLevel(Levels.Count);
                }
                else
                {
                    result = GetLevel(levelOffset);
                }
            }

            return result;
        }

        public PlayerData GetFirstPlayer()
        {
            return _players[0];
        }
    }
}