using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour, IDamagable
{
    [SerializeField] int maxHealth = 2;
    public UnityEvent OnDead,OnHit;
    public int health{
        get;
        set;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(){
        health-=1;
        OnHit?.Invoke();
        if(health<=0){
            OnDead?.Invoke();
            GetComponent<Movable>().enabled=false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
