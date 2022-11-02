using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Storage
{
    public interface IStoragable
    {
        void Save();

        void Load();

        event System.Action OnLoadCompleteEvent;
    }

    public interface IStoragable<Tdata>
    {
        void Save(Tdata data);

        void Load(Tdata data);
    }

    public interface IStoragableDictionary : IStoragable<Dictionary<string, object>>
    {

    }
}
