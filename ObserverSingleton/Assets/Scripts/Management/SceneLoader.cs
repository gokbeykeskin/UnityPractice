using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Awake()
    {
        SceneManager.sceneLoaded += GameManager.NotifyLoadScene;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= GameManager.NotifyLoadScene;
    }

    public void LoadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    void Update()
    {
        
    }
}
