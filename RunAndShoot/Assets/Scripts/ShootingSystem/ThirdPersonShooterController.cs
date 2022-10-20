using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{

    public UnityEvent<Vector3> OnAim,OnShoot;
    public UnityEvent OnAimRelease;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    StarterAssetsInputs starterAssetsInputs;

    void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width /2f, Screen.height /2f);

        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask)){
            mouseWorldPosition = raycastHit.point;
        }

        if(starterAssetsInputs.aim){
            OnAim?.Invoke(mouseWorldPosition);
           
           
        }
        else{ 
            OnAimRelease?.Invoke();
        }

        if(starterAssetsInputs.shoot){
            OnShoot?.Invoke(mouseWorldPosition);
        }

        



    }
}
