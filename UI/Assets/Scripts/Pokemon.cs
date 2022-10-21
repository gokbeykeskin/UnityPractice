using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
[Serializable]
public class Pokemon : MonoBehaviour
{
    [SerializeField] public TMP_Text nameTag;
    [SerializeField] public TMP_Text buyText,amountText;
    [SerializeField] public int price;
    


    void Start()
    {
        
        if(nameTag!=null) nameTag.text = this.name;
        buyText.text = "Buy (" + price.ToString() + "$)";
        
    }

    public void UpdateAmount(int amount){
        amountText.text = amount.ToString();
    }

    public int GetPrice(){
        return price;
    }
}
