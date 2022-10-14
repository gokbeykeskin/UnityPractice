using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackManager : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] float bulletSpeed=20f;
    float elapsedTime;

    void Awake()
    {
        elapsedTime=Time.time;
    }
    void Update()
    {
        
        if(Time.time > elapsedTime+0.5f && Input.GetMouseButtonDown(0)){
            elapsedTime=Time.time;
            Attack();
        }
    }

    void Attack(){
        var shotBullet = Instantiate(bullet,shootPoint.position,Quaternion.identity);
        Rigidbody2D bulletRB = shotBullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = transform.localScale.x * new Vector2(bulletSpeed,bulletRB.velocity.y);
    }
    
}
