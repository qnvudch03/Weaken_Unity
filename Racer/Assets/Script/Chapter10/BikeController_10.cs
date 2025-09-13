using NUnit.Framework;
using Pattern.Visitor;
using System.Collections.Generic;
using UnityEngine;

public class BikeController_10 : MonoBehaviour, IBikeElement
{
    private List<IBikeElement> bikeElemts = new List<IBikeElement>();
    //private List<IBikeElement> _bikeElements =
    //       new List<IBikeElement>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bikeElemts.Add(gameObject.AddComponent<BikeShield>());
        bikeElemts.Add(gameObject.AddComponent<BikeWeapon>());
        bikeElemts.Add(gameObject.AddComponent<BikeEngine>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Accept(IVisitor visitor)
    {
        foreach (IBikeElement element in bikeElemts)
        {
            element.Accept(visitor);
        }
    }
}
