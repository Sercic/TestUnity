using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableKeyValuePair<TKey, TValue>
{
    public TKey Key;
    public TValue Value;
}

[Serializable]
public class SerizlizerDictionaryInspector<TKey, TValue>
{
    public List<SerializableKeyValuePair<TKey, TValue>> keyValuePairs = new List<SerializableKeyValuePair<TKey, TValue>>();

    // 提供一个方法来添加键值对  
    public void Add(TKey key, TValue value)
    {
        var kvp = new SerializableKeyValuePair<TKey, TValue> { Key = key, Value = value };
        keyValuePairs.Add(kvp);
    }
    // 检查是否包含键的方法  
    public bool ContainsKey(TKey key)
    {
        foreach (var kvp in keyValuePairs)
        {
            if (kvp.Key.Equals(key))
            {
                return true;
            }
        }
        return false;
    }

    // 提供一个方法来获取键值对  
    public bool TryGetValue(TKey key, out TValue value)
    {
        foreach (var kvp in keyValuePairs)
        {
            if (kvp.Key.Equals(key))
            {
                value = kvp.Value;
                return true;
            }
        }
        value = default(TValue);
        return false;
    }

    // 移除键值对的方法  
    public bool Remove(TKey key)
    {
        for (int i = 0; i < keyValuePairs.Count; i++)
        {
            if (keyValuePairs[i].Key.Equals(key))
            {
                keyValuePairs.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // 通过索引器获取Value  
    public TValue this[TKey key]
    {
        get
        {
            foreach (var kvp in keyValuePairs)
            {
                if (kvp.Key.Equals(key))
                {
                    return kvp.Value;
                }
            }
            throw new KeyNotFoundException($"Key {key} not found in dictionary.");
        }
        set
        {
            var kvp = keyValuePairs.Find(kvp => kvp.Key.Equals(key));
            if (kvp != null)
            {
                kvp.Value = value;
            }
            else
            {
                Add(key, value);
            }
        }
    }
    // 其他你需要的字典操作方法...  
}