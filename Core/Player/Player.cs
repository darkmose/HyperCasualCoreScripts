using Core.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PlayerModule
{

    public interface IPlayer: IStoragable, IStoragable<StorageData>
    {
        IPrivacyPolicy Policy { get; }
        ISettings Settings { get; }
        IWallet Wallet { get; }
        ILevelProgression LevelProgression { get; }
    }

    public class Player : IPlayer
    {
        public IPrivacyPolicy Policy { get; private set; }

        public ISettings Settings { get; private set; }

        public IWallet Wallet { get; private set; }

        public ILevelProgression LevelProgression { get; private set; }

        private List<IStoragable> _storagables = new List<IStoragable>();
        private List<IStoragable<StorageData>> _storagablesStorageData = new List<IStoragable<StorageData>>();

        public Player(IPrivacyPolicy policy, ISettings settings, IWallet wallet, ILevelProgression levelProgression)
        {
            Policy = policy;
            Settings = settings;
            Wallet = wallet;
            LevelProgression = levelProgression;
            RegisterStoragable(policy, settings, wallet, levelProgression);
            RegisterStoragableStorageData(policy, settings, wallet, levelProgression);
        }

        private void RegisterStoragable(params object[] storagables)
        {
            foreach (var storagable in storagables)
            {
                if (storagable is IStoragable)
                {
                    _storagables.Add(storagable as IStoragable);
                }
            }
        }

        private void RegisterStoragableStorageData(params object[] storagables)
        {
            foreach (var storagable in storagables)
            {
                if (storagable is IStoragable<StorageData>)
                {
                    _storagablesStorageData.Add(storagable as IStoragable<StorageData>);
                }
            }
        }

        public void Save()
        {
            foreach (var storagable in _storagables)
            {
                storagable.Save();
            }
        }

        public void Load()
        {
            foreach (var storagable in _storagables)
            {
                storagable.Load();
            }
        }

        public void Save(StorageData data)
        {
            foreach (var storagable in _storagablesStorageData)
            {
                storagable.Save(data);
            }
        }

        public void Load(StorageData data)
        {
            foreach (var storagable in _storagablesStorageData)
            {
                storagable.Load(data);
            }
        }
    }
}