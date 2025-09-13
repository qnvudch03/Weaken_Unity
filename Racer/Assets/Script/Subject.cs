using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    
    // 1. ArrayList 말고, Objectalbe 같은걸로 바꿀수 있으면 바꾸자
    //private readonly ArrayList observers = new ArrayList();

    //수정 1
   private readonly HashSet<Observer> observers = new HashSet<Observer>();

    public void Attach(Observer observer)
    {
        observers.Add(observer);
        
    }

    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }

    //public void NotifyObservers()
    //{
    //    foreach(Observer observer in observers)
    //    {
    //        observer.OnCatchEvent(this);
    //    }
    //}



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
