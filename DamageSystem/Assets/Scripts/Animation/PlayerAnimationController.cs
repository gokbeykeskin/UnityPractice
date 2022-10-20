using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    public void AttackAnim(){
        StartCoroutine(PlayAttackAnim());
    }

    public void WalkingAnim(){
        animator.SetBool("Jump",false);
        animator.SetBool("Run",true);
    }

    public void JumpingAnim(){
        animator.SetBool("Jump",true);
    }

    public void IdleAnim(){
        animator.SetBool("Run",false);
        animator.SetBool("Jump",false);
    }


    IEnumerator PlayAttackAnim(){
        animator.SetBool("Attack",true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Attack",false);
    }

}
