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

    // �ṩһ����������Ӽ�ֵ��  
    public void Add(TKey key, TValue value)
    {
        var kvp = new SerializableKeyValuePair<TKey, TValue> { Key = key, Value = value };
        keyValuePairs.Add(kvp);
    }
    // ����Ƿ�������ķ���  
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

    // �ṩһ����������ȡ��ֵ��  
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

    // �Ƴ���ֵ�Եķ���  
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

    // ͨ����������ȡValue  
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
    // ��������Ҫ���ֵ��������...  
}