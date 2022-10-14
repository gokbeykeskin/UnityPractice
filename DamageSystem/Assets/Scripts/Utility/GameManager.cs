using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton
{
    int enemiesLeft;
    // Start is called before the first frame update
    void Awake()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemyDead(){
        enemiesLeft-=1;
        if(enemiesLeft<=0) StartCoroutine(RestartGame());
    }

    public void PlayerDead(){
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame(){
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
