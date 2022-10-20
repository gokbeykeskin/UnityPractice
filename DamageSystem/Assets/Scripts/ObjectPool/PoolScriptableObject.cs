using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="PoolScriptableObject",menuName = "ScriptableObjects/Pool")]
public class PoolScriptableObject : ScriptableObject
{
    public Queue<GameObject> pooledObjects;
    public GameObject objectPrefab;
    public int poolSize;
}

