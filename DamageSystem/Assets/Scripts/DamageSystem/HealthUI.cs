using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] List<Image> hearths;
    Stack<Image> hearthImages;

    void Awake()
    {
        hearthImages = new Stack<Image>();
        foreach(var hearth in hearths)
            hearthImages.Push(hearth);
    }
    public void RemoveHearth(){
        Image hearth = hearthImages.Pop();
        hearth.gameObject.SetActive(false);
    }
}
