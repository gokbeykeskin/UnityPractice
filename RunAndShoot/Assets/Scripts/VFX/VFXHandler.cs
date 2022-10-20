using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;


    public void PlayMuzzleClip(){
        StartCoroutine(PlayMuzzle());
    }

    IEnumerator PlayMuzzle(){
        muzzleFlash.Play();
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.Stop();
    }


}
