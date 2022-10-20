using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class ShootAnimController : MonoBehaviour
{
    Animator animator;
    StarterAssetsInputs _input;

    void Awake()
    {
        animator = GetComponent<Animator>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    public void SetAimAnimation(){
        animator.SetBool("Shoot",true);
    }

    public void ReleaseAimAnimation(){
        animator.SetBool("Shoot",false);
    }
}
