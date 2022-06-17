using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Storage
{
    public interface IStoragable
    {
        void Save();

        void Load();
    }

    public interface IStoragable<Tdata>
    {
        void Save(Tdata data);

        void Load(Tdata data);
    }

    [System.Serializable]
    public class StorageData
    {
        public int CurrentLevel;
        public int Coins;

        public StoreStorageData StoreData;
    }

    [System.Serializable]
    public class StoreStorageData { }
}
