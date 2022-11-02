using Core.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Resourses
{
    [CreateAssetMenu(fileName = "ResourceHolder", menuName = "ScriptableObjects/Resource Holder")]
    public class ResourceHolder : ScriptableObject
    {
        public List<LevelData> Levels => _levels;
        public List<GameObject> Prefabs => _prefabs;
        public ToastMessage ToastMessagePrefab => _toastMessagePrefab;
        public ToastMessage ToastImageMoneyPrefab => _toastImageMoneyPrefab;

        [SerializeField] private List<LevelData> _levels = new List<LevelData>();
        [SerializeField] private List<GameObject> _prefabs = new List<GameObject>();
        [SerializeField] private ToastMessage _toastMessagePrefab;
        [SerializeField] private ToastMessage _toastImageMoneyPrefab;

        public LevelData GetLevel(int levelNumber)
        {
            var result = _levels.Find(levelData => levelData.LevelNumber == levelNumber);

            return result;
        }

        public GameObject GetPrefab(string prefabName)
        {
            return _prefabs.Find(prefab => prefab.name == prefabName);
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
    }
}