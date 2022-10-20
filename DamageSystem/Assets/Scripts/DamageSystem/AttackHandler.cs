using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] float bulletSpeed=20f;
    [SerializeField] ObjectPoolingHandler pool;
    float elapsedTime;

    void Awake()
    {
        elapsedTime=Time.time;
    }

    

    public void Attack(){
        if(Time.time > elapsedTime+0.5f)
        {
            elapsedTime=Time.time;

            RaycastHit2D rayHit = Physics2D.Raycast(shootPoint.position,transform.localScale.x * transform.right);
            var rayHitDamagable = rayHit.collider.GetComponent<IDamagable>();
            if(rayHitDamagable !=null){
               rayHitDamagable.TakeDamage(1); 
            }
            var shotBullet = pool.GetPooledObject(0);
            shotBullet.transform.position = shootPoint.position;
            Rigidbody2D bulletRB = shotBullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = transform.localScale.x * new Vector2(bulletSpeed,0);
        }
        
    }
    
}
