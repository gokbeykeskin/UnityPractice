using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MyDictionary<K,V>
{
    protected struct Pair{
        public K key;
        public V value;
        public Pair(K key,V value){
            this.key = key;
            this.value = value;
        }
    }

    MyList<Pair> KWPairs;
    int size,capacity;
    public MyDictionary(){
        KWPairs = new MyList<Pair>();
    }
    public MyDictionary(int capacity){
        KWPairs = new MyList<Pair>(capacity);
    }

    public void Add(K key, V value){
        KWPairs.Append(new Pair(key,value));
        size++;
    }

    public V Contains(K key){
        for(int i=0;i<size;i++){
            Pair pair =  KWPairs.Get(i);
            Debug.Log("pair:"+pair.key+"|"+pair.value);
            if(pair.key.Equals(key)) return pair.value;
        }
        return default(V);
    }

}
