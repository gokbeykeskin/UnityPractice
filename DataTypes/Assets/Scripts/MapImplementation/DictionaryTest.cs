using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DictionaryTest : MonoBehaviour
{
    MyDictionary<string,string> dictionary;
    [SerializeField] TMP_Text containsText;
    [SerializeField] InputField checkInput,addInputKey,addInputValue;
    [SerializeField] Button checkButton,addButton;
    // Start is called before the first frame update
    void Start()
    {
        dictionary = new MyDictionary<string,string>();
    }

    public void Add(){
        dictionary.Add(addInputKey.text,addInputValue.text);
        addInputKey.text = "";
        addInputValue.text = "";
    }

    public void ContainsCheck(){
        string value = dictionary.Contains(checkInput.text);
        checkInput.text = "";
        if(value!=null) containsText.text="Value:"+ value;
        else containsText.text = "Dictionary doesn't contains this key";
    }

}
