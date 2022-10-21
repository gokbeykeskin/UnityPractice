using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
[Serializable]
public class BuyHandler : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] TMP_Text moneyText;
    Dictionary<Pokemon,int> pokemons; //pokemons and amounts

    void Start()
    {
        money = PlayerPrefs.GetInt("Money",money);
        pokemons = JSONHandler.ReadFromJSON<Pokemon,int>("pokemons");
        foreach(var pokemon in pokemons){
            pokemon.Key.UpdateAmount(pokemon.Value);
        }
        moneyText.text = money.ToString();
    }

    public void BuyPokemon(Pokemon pokemon){
        int price = pokemon.GetPrice();
        if(price>money) return;
        money-=price;
        PlayerPrefs.SetInt("Money",money);
        int currentCount;
        pokemons.TryGetValue(pokemon,out currentCount);
        currentCount+=1;
        pokemons[pokemon] = currentCount;
        pokemon.UpdateAmount(currentCount);
        moneyText.text=money.ToString();
        Debug.Log(pokemons[pokemon]);
        JSONHandler.SaveToJSON<Pokemon,int>(pokemons,"pokemons");
    }

    public void GetMoney(int amount){
        money+=amount;
        moneyText.text = money.ToString();
        PlayerPrefs.SetInt("Money",money);
    }
}
