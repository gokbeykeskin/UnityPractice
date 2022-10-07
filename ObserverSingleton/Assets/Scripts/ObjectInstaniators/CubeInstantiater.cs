using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class CubeInstantiater : MonoBehaviour
{
    //Observer2
    [SerializeField] GameObject cubePrefab;
    public ObjectSpawned cubeSpawned;
    //Added the listener on editor. (sapphireInstaniater.InstantiateSapphire)
    void Awake()
    {
        GameManager.OnSceneLoad += SpawnCube;
    }
    void OnDestroy()
    {
        GameManager.OnSceneLoad -= SpawnCube;
    }
    public void SpawnCube(){

        Instantiate(cubePrefab,Vector3.zero,Quaternion.identity);
        Color newColor = new Color(UnityEngine.Random.value,UnityEngine.Random.value,UnityEngine.Random.value);
        cubePrefab.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", newColor);
        cubeSpawned?.Invoke(newColor);
    }



    [Serializable] public class ObjectSpawned : UnityEvent<Color>{}

}
