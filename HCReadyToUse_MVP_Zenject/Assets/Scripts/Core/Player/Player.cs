using Core.Storage;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using Core.Events;

namespace Core.PlayerModule
{
    public interface IPlayer: IStoragable
    {
        IPrivacyPolicy Policy { get; }
        ISettings Settings { get; }
        IWallet Wallet { get; }
        ILevelProgression LevelProgression { get; }
    }

    public class Player : IPlayer
    {
        private static string _path = Application.persistentDataPath + "/playerData.json";

        public event System.Action OnLoadCompleteEvent;

        public IPrivacyPolicy Policy { get; private set; }

        public ISettings Settings { get; private set; }

        public IWallet Wallet { get; private set; }

        public ILevelProgression LevelProgression { get; private set; }

        private List<IStoragableDictionary> _storagablesDictionaries = new List<IStoragableDictionary>();

        private Dictionary<string, object> _saveDataDictionary = new Dictionary<string, object>();
        private Dictionary<string, object> _loadDataDictionary = new Dictionary<string, object>();

        public Player(IPrivacyPolicy policy, ISettings settings, IWallet wallet, ILevelProgression levelProgression)
        {
            Policy = policy;
            Settings = settings;
            Wallet = wallet;
            LevelProgression = levelProgression;

            RegisterStoragableDictionaries(policy, settings, wallet, levelProgression);
        }

        private void RegisterStoragableDictionaries(params object[] storagables)
        {
            foreach (var storagable in storagables)
            {
                if (storagable is IStoragableDictionary)
                {
                    _storagablesDictionaries.Add(storagable as IStoragableDictionary);
                }
            }
        }

        public void Save()
        {
            var data = CollectData();
            var saveData = JsonConvert.SerializeObject(data, Formatting.Indented);
            var storageManager = new StorageManager(SavingPlace.File);
            storageManager.Save(_path, saveData);
        }

        public void Load()
        {
            LoadPlayerData();
        }

        public Dictionary<string, object> CollectData()
        {
            foreach (var storagable in _storagablesDictionaries)
            {
                storagable.Save(_saveDataDictionary);
            }
            return _saveDataDictionary;
        }

        public void LoadPlayerData()
        {
            var storageManager = new StorageManager(SavingPlace.File);

            if (storageManager.Exists(_path))
            {
                storageManager.Load(_path, OnLoadComplete);
            }
            else
            {
                OnLoadCompleteEvent?.Invoke();
            }
        }

        private void OnLoadComplete(string data)
        {
            _loadDataDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);

            if (_loadDataDictionary.Count == 0)
            {
                return;
            }

            foreach (var storagable in _storagablesDictionaries)
            {
                storagable.Load(_loadDataDictionary);
            }

            OnLoadCompleteEvent?.Invoke();
        }
    }
}