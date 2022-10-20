using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] float normalSensitivity,aimSensitivity;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform gunTip;
    [SerializeField] private ObjectPoolingHandler poolingHandler;
    StarterAssetsInputs starterAssetsInputs;
    ThirdPersonController thirdPersonController;
    [SerializeField] float shootForce=100f;


    void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    public void SetAimCamera(){
         aimVirtualCamera.gameObject.SetActive(true);
    }

    public void SetAimPhysics(Vector3 mouseWorldPosition){
        thirdPersonController.SetSensitivity(aimSensitivity);
        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward,aimDirection,Time.deltaTime*20f); 
        thirdPersonController.SetRotateOnMove(false);
    }

    public void SetNormalCamera(){
        aimVirtualCamera.gameObject.SetActive(false);
    }

    public void SetNormalPhysics(){
        thirdPersonController.SetRotateOnMove(true);
        thirdPersonController.SetSensitivity(normalSensitivity);
    }

    public void Shoot(Vector3 mouseWorldPosition){
            Vector3 aimDir = (mouseWorldPosition - gunTip.position).normalized;
            GameObject bullet = poolingHandler.GetPooledObject(0);
            bullet.transform.position = gunTip.position;
            bullet.transform.rotation = Quaternion.LookRotation(aimDir,Vector3.up);
            bullet.GetComponent<Rigidbody>().velocity = aimDir.normalized * shootForce;
            starterAssetsInputs.shoot = false;
    }
}
