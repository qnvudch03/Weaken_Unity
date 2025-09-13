using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    
    // 1. ArrayList ����, Objectalbe �����ɷ� �ٲܼ� ������ �ٲ���
    //private readonly ArrayList observers = new ArrayList();

    //���� 1
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
