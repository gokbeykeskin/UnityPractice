using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable)){
            damagable.TakeDamage();
        }
        Destroy(gameObject);

    }
}
