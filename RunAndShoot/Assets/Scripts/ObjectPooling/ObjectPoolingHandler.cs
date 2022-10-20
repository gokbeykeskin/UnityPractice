using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolingHandler : MonoBehaviour
{
    [SerializeField] List<PoolScriptableObject> pools;

    private void Awake(){
        foreach(var pool in pools){
            pool.pooledObjects = new Queue<GameObject>();
            for(int i=0;i<pool.poolSize;i++){
                GameObject obj = Instantiate(pool.objectPrefab);
                obj.SetActive(false);
                pool.pooledObjects.Enqueue(obj);
                Debug.Log(obj.name);
            }
        }
    }

    public GameObject GetPooledObject(int poolIndex){
        if(poolIndex>pools.Count) return null;
        GameObject obj = pools[poolIndex].pooledObjects.Dequeue();
        obj.SetActive(true);
        pools[poolIndex].pooledObjects.Enqueue(obj);
        return obj;
    }
}
