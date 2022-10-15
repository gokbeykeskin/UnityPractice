using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    void Update()
    {
        transform.Translate(transform.forward * (Time.deltaTime * 30));
    }
}
