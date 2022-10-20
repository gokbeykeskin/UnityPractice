using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public UnityEvent OnLeftMouseClick;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) OnLeftMouseClick?.Invoke();
    }
}
