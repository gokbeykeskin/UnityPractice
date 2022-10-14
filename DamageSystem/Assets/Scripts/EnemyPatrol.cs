using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyPatrol : Movable
{
    Tweener tweener;
    bool isDead=false;
    // Start is called before the first frame update
    void Start()
    {
        Move(-12f);
    }

    
    protected override void Move(float moveDir)
    {
        tweener = transform.DOMoveX(moveDir,8).SetLoops(-1,LoopType.Yoyo).OnStepComplete(Flip).SetEase(Ease.Unset);
    }   

    public void StopPatrol(){
        tweener.Kill();
        isDead=true;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(isDead) return;
        collisionInfo.gameObject.GetComponent<Rigidbody2D>()?.AddRelativeForce(new Vector2(-2500f,10f),ForceMode2D.Impulse);

        if(collisionInfo.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable)){
            damagable.TakeDamage();
            
        }
    }
    

}
