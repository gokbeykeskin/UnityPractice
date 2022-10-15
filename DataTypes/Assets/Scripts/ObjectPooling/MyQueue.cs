using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQueue<T>
{
    T[] elements;
    int front,rear,capacity,size;
    
    public MyQueue(){
        size=0;
        capacity=50;
        front = 0;
        rear = -1;
        elements = new T[capacity];

    }

    public MyQueue(int capacity){
        size=0;
        this.capacity=capacity;
        front = 0;
        rear = -1; 
        elements = new T[capacity];

    }

    public void Enqueue(T item){
        if(size++ == capacity){
            capacity*=2;
            T[] newArr = new T[capacity];
            for(int i=0;i<capacity/2;i++){
                newArr[i]=elements[i];
            }
            elements = newArr;
        }
        rear = (rear+1) % capacity;
        elements[rear] = item;
    }

    public T Dequeue(){
        if(front==rear+1) return default(T); //null
        size-=1;
        T returnVal = elements[front];
        front = (front+1) % capacity;
        return returnVal;
    }

}
