using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour
{
    protected bool grounded=false;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected bool facingRight=true;

    [SerializeField] float jumpForce=5f;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag=="Ground") grounded=true;
    }

    void  OnCollisionExit2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag=="Ground") grounded=false;
    }


    protected abstract void Move(float moveDir);

    protected void Jump(){
        rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
    }

    protected void Flip(){
        Vector3 scale = transform.localScale;
        scale.x *=-1;
        transform.localScale = scale;
        facingRight= !facingRight;
    }
}
