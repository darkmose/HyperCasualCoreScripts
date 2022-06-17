using Core.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PlayerModule
{
    public interface ILevelProgression: IStoragable, IStoragable<StorageData>
    {
        int CurrentLevel { get; }

        void SetLevelNumber(int levelNumber);
    }

    public class LevelProgression : ILevelProgression
    {
        public int CurrentLevel { get; private set; } = 1;

        private const string StorageKey = nameof(LevelProgression);

        public void Load()
        {
            CurrentLevel = PlayerPrefs.GetInt(StorageKey, 1);
        }

        public void Load(StorageData data)
        {
            CurrentLevel = data.CurrentLevel;
        }

        public void Save()
        {
            PlayerPrefs.SetInt(StorageKey, CurrentLevel);
        }

        public void Save(StorageData data)
        {
            data.CurrentLevel = CurrentLevel;
        }

        public void SetLevelNumber(int levelNumber)
        {
            CurrentLevel = levelNumber;
        }
    }
}