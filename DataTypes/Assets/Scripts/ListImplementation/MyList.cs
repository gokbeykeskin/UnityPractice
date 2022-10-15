using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyList<T>
{
    private T[] elements;
    public int Length;
    private int capacity;

    public MyList(){
        Length=0;
        capacity = 50;
        elements = new T[capacity]; 
    }

    public MyList(int capacity){
        Length=0;
        this.capacity = capacity;
        elements = new T[capacity]; 
    }

    public void Insert(int index,T value){
        if(Length==capacity){
            capacity*=2;
            T[] newArr = new T[capacity];
            for(int i=0;i<Length;i++){
                newArr[i] = elements[i];
            }
            elements = newArr;
        }
        Length+=1;
        for(int i=Length-1;i>index;i--){
            elements[i]=elements[i-1];
        }
        elements[index] = value;
    }

    public void Append(T value){
        Insert(Length,value);
    }

    public void Remove(int index){
        if(Length==0) return;
        for(int i=index;i<Length-1;i++){
            elements[i] = elements[i+1];
        }
        Length-=1;

    }

    public void RemoveLast(){
        Remove(Length-1);
    }



    public T Get(int index){
        if(index<0|| index>=Length) return default(T);
        return elements[index];
    }

    public T GetLast(){
        return Get(Length-1);
    }





}
