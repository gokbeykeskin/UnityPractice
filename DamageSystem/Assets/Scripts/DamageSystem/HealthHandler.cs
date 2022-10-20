using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour, IDamagable
{
    [SerializeField] int maxHealth = 2;
    public UnityEvent OnDead,OnHit;
    Movable movable;
    public int health{
        get;
        set;
    }
    // Start is called before the first frame update
    void Start()
    {
        movable=GetComponent<Movable>();
        health = maxHealth;
    }


    public void TakeDamage(int damage){

        if(health>0){
            health-=damage;
            OnHit?.Invoke();
        }
        
        if(health<=0){
            OnDead?.Invoke();
            movable.ToggleMovement();
        }

    }
}
