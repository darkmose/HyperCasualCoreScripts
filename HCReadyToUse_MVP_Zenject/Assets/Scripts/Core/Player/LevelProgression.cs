using Core.Storage;
using Core.UI;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PlayerModule
{
    public interface ILevelProgression: IStoragableDictionary
    {
        IPropertyReadOnly<int> CurrentLevel { get; }
        void SetLevelNumber(int levelNumber);
    }

    public class LevelProgression : ILevelProgression
    {
        private const string StorageKey = nameof(LevelProgression);
        private IntProperty _currentLevel = new IntProperty(1);
        public IPropertyReadOnly<int> CurrentLevel => _currentLevel;

        public void SetLevelNumber(int levelNumber)
        {
            _currentLevel.SetValue(levelNumber, true);
        }

        public void Save(Dictionary<string, object> data)
        {
            data[nameof(LevelProgression)] = new Dictionary<string, object>()
            {
                [nameof(CurrentLevel)] = CurrentLevel.Value,
            };
        }

        public void Load(Dictionary<string, object> data)
        {
            if (data.ContainsKey(nameof(LevelProgression)))
            {
                var storageData = (JObject)data[nameof(LevelProgression)];
                var level = (int)storageData[nameof(CurrentLevel)];
                SetLevelNumber(level);
            }
        }
    }
}