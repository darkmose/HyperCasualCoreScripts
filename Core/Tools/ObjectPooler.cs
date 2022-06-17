using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler
{
    private Dictionary<string, Queue<GameObject>> _poolDictionary = new Dictionary<string, Queue<GameObject>>();
    private Dictionary<string, GameObject> _tagPrefabs = new Dictionary<string, GameObject>();

    public bool IsDynamicExtended { get; private set; }
    public int DynamicExtendCount { get; private set; }
    
    public Transform rootOfPooledGameobjects;

    public ObjectPooler(Transform rootOfObjects, bool isDynamicExtend, int dynamicExtendCount = 0) 
    {
        rootOfPooledGameobjects = rootOfObjects;
        IsDynamicExtended = isDynamicExtend;
        DynamicExtendCount = dynamicExtendCount;
    }

    [System.Serializable]
    class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public void ReturnObjects()
    {
        foreach (var pool in _poolDictionary)
        {
            foreach (var obj in pool.Value)
            {
                if (!System.Object.ReferenceEquals(obj.transform.parent, rootOfPooledGameobjects))
                {
                    obj.SetActive(false);
                    obj.transform.SetParent(rootOfPooledGameobjects);
                }
            }
        }
    }

    public GameObject GetPooledGameObject(string tag)
    {
        if (_poolDictionary.ContainsKey(tag))
        {
            Queue<GameObject> pool = _poolDictionary[tag];
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            _poolDictionary[tag]. Enqueue(obj);
            return obj;
        }
        Debug.Log($"'{tag}' tag doesn't exist");
        return null;
    }

    public void ExtendPool(string tag, int countNeeded) // пока не используется
    {
        if (_poolDictionary.ContainsKey(tag))
        {
            Queue<GameObject> objects = _poolDictionary[tag];
            var currentPool = _tagPrefabs[tag];

            for (int i = 0; i < countNeeded; i++)
            {
                GameObject extendObj = GameObject.Instantiate(currentPool);
                extendObj.transform.SetParent(rootOfPooledGameobjects);
                extendObj.SetActive(false);
                objects.Enqueue(extendObj);
            }            
        }

    }

    public void CreatePool(string tagName, GameObject prefab, int count) 
    {
        if (_poolDictionary.ContainsKey(tagName))
        {
            Debug.Log($"Tagname {tagName} is already exist");
            return;
        }
        Queue<GameObject> objects = new Queue<GameObject>();
        _tagPrefabs.Add(tagName, prefab);

        for (int i = 0; i < count; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.transform.SetParent(rootOfPooledGameobjects);
            obj.SetActive(false);
            objects.Enqueue(obj);
        }
        _poolDictionary.Add(tagName, objects);
    }

}
