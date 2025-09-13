using UnityEngine;

public class ClientObserver : MonoBehaviour
{
    private BikeController_9 bikeController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bikeController = (BikeController_9)FindObjectOfType(typeof(BikeController_9));
        bikeController = (BikeController_9)FindFirstObjectByType<BikeController_9>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Damage Bike"))
            if (bikeController)
                bikeController.TakeDamage();

        if (GUILayout.Button("Toggle Turbo"))
            if ((bikeController))
            {
                bikeController.ToggleTurbo();
            }
    }
}
