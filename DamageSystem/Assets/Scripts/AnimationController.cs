using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    
    protected Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void DeathAnim(){
        animator.SetBool("Dead",true);
    }
}
