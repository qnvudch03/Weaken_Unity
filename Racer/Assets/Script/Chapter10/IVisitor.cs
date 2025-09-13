using Pattern.Visitor;
using UnityEngine;

public interface IVisitor
{
    void Visit(BikeShield bikeShield);
    void Visit(BikeEngine bikeEngine);
    void Visit(BikeWeapon bikeWeapon);
}
