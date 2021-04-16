using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public int size;
        public GameObject prefab;
    }

    public List<Pool> pools;

    Dictionary<string, Queue<GameObject>> dictionaryPool;

    private void Start()
    {
        dictionaryPool = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objQueue = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject go = Instantiate(pool.prefab);

                go.SetActive(false);

                objQueue.Enqueue(go);
            }

            dictionaryPool.Add(pool.name,objQueue);
        }
    }
    /// <summary>
    /// Get object from Pool
    /// </summary>
    /// <param name="_name"></param>
    /// <param name="_position"></param>
    /// <param name="_rotation"></param>
    /// <returns></returns>
    public GameObject GetObjectFromPool(string _name, Vector3 _position, Quaternion _rotation)
    {
        if (!dictionaryPool.ContainsKey(_name))
        {
            return null;
        }

        GameObject obj = dictionaryPool[_name].Dequeue();

        obj.transform.SetPositionAndRotation(_position, _rotation);

        obj.SetActive(true);

        dictionaryPool[_name].Enqueue(obj);

        return obj;
    }
}
