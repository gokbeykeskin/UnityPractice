using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    [SerializeField] float spawnDelay = 0.5f;
    ObjectPooling objectPool;

    void Awake()
    {
        objectPool = GetComponent<ObjectPooling>();
    }

    void Start()
    {
        StartCoroutine(PoolRoutine());
    }


    private IEnumerator PoolRoutine()
    {
        int counter = 0;
        while (true)
        {

            GameObject obj = objectPool.GetPooledObject(counter++ % 3);
            obj.transform.position = new Vector3(0f,5f,0f);
            //if(obj.name)
            yield return  new WaitForSeconds(spawnDelay);
        }
    }

}


