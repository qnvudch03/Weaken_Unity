using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ClientStrategy : MonoBehaviour
{
    private GameObject dron;

    private List<IManoeuvreBehaviour> components = new List<IManoeuvreBehaviour>();

    private void SpawnDrone()
    {
        dron = GameObject.CreatePrimitive(PrimitiveType.Cube);
        dron.AddComponent<Drone_11>();

        dron.transform.position = Random.insideUnitSphere * 10;

        ApplyRandomStrategies();
    }

    private void ApplyRandomStrategies()
    {
        components.Add(dron.AddComponent<ManoeuvreUpDown>());
        components.Add(dron.AddComponent<ManoeuvreLeftRight>());
        components.Add(dron.AddComponent<ManoeuvreBack>());

        int randomIndex = Random.Range(0, components.Count);

        dron.GetComponent<Drone_11>().ApplyStrategy(components[randomIndex]);
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Spawn Drone"))
        {
            SpawnDrone();
        }
    }
}
