using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogger : MonoBehaviour
{
    //Observer1
    void Awake()
    {
        GameManager.OnSceneLoad +=SceneLoadDebug;
    }

    void OnDestroy()
    {
        GameManager.OnSceneLoad -=SceneLoadDebug;
    }

    public void SceneLoadDebug(){
        Debug.Log("New Scene Loaded.");
    }

}
