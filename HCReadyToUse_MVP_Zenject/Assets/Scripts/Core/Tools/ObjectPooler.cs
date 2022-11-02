using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler<TPool> where TPool : MonoBehaviour
{
    private Dictionary<string, Queue<TPool>> _poolDictionary = new Dictionary<string, Queue<TPool>>();
    private Dictionary<string, TPool> _tagPrefabs = new Dictionary<string, TPool>();

    public bool IsDynamicExtended { get; private set; }
    public int DynamicExtendCount { get; private set; }
    
    public Transform rootOfPooledGameobjects;

    public ObjectPooler(Transform rootOfObjects, bool isDynamicExtend, int dynamicExtendCount = 0) 
    {
        rootOfPooledGameobjects = rootOfObjects;
        IsDynamicExtended = isDynamicExtend;
        DynamicExtendCount = dynamicExtendCount;
    }

    public void ReturnObjects()
    {
        foreach (var pool in _poolDictionary)
        {
            foreach (var obj in pool.Value)
            {
                if (!System.Object.ReferenceEquals(obj.transform.parent, rootOfPooledGameobjects))
                {
                    obj.gameObject.SetActive(false);
                    obj.transform.SetParent(rootOfPooledGameobjects);
                }
            }
        }
    }

    public void ReturnObjectToParent(GameObject gameObject)
    {
        gameObject.transform.SetParent(rootOfPooledGameobjects);
    }

    public TPool GetPooledGameObject(string tag)
    {
        if (_poolDictionary.ContainsKey(tag))
        {
            Queue<TPool> pool = _poolDictionary[tag];
            TPool obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            _poolDictionary[tag].Enqueue(obj);
            return obj;
        }
        Debug.Log($"'{tag}' tag doesn't exist");
        return null;
    }

    public void CreatePool(string tagName, TPool prefab, int count) 
    {
        if (_poolDictionary.ContainsKey(tagName))
        {
            Debug.Log($"Tagname {tagName} is already exist");
            return;
        }
        Queue<TPool> objects = new Queue<TPool>();
        _tagPrefabs.Add(tagName, prefab);

        for (int i = 0; i < count; i++)
        {
            TPool obj = GameObject.Instantiate(prefab);
            obj.transform.SetParent(rootOfPooledGameobjects);
            obj.gameObject.SetActive(false);
            objects.Enqueue(obj);
        }
        _poolDictionary.Add(tagName, objects);
    }
}
