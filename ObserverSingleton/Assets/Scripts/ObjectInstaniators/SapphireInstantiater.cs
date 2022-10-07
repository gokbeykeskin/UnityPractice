using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapphireInstantiater : MonoBehaviour
{
    [SerializeField] GameObject sapphirePrefab;
    public void SpawnSapphire(Color color){
        Instantiate(sapphirePrefab,Vector3.up*2,Quaternion.identity);
        sapphirePrefab.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", color);

    }
}
