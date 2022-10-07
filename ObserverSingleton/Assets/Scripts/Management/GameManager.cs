using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoSingleton
{
    //Subject
    public static Action OnSceneLoad;

    public static void NotifyLoadScene(Scene scene,LoadSceneMode mode){
        OnSceneLoad?.Invoke();
    }






}
