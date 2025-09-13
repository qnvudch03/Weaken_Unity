using System.Diagnostics;
using System.Text;
using UnityEngine;

public class HUDController_9 : MonoBehaviour, SubScriber
{
    private bool isTurboOn;
    private float currentHealth;
    private BikeController_9 bikeController;

    private void Start()
    {
        Subscrive(EventType.TurboOn);
        Subscrive(EventType.TakeDamage);
    }

    void OnGUI()
    {
        GUILayout.BeginArea(
            new Rect(50, 50, 100, 200));
        GUILayout.BeginHorizontal("box");

        StringBuilder sb = new StringBuilder();
        sb.Append("Health: ");
        sb.Append(currentHealth);
        GUILayout.Label(sb.ToString());

        GUILayout.EndHorizontal();

        if(isTurboOn )
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Turbo Activated!");
            GUILayout.EndHorizontal();
        }

        if(currentHealth <= 50.0f)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("WARNING: Low Health");
            GUILayout.EndHorizontal();
        }

        GUILayout.EndArea();
    }

    public void Subscrive(EventType concernedEvent)
    {
        EventManager.Instance.SubScribeEvent(concernedEvent, this);
    }

    public void RecieveEvent(EventType broadCastedEvent, BikeController_9 publisher)
    {
        switch(broadCastedEvent)
        {
            case EventType.TakeDamage:
                break;

            case EventType.TurboOn:
                break;
        }

        currentHealth = publisher.CurrentHealth;
        isTurboOn = publisher.IsTurboOn;
    }

    //public override void OnCatchEvent(Subject subject)
    //{
    //    if (!bikeController)
    //        bikeController = subject.GetComponent<BikeController_9>();

    //    if(bikeController)
    //    {
    //        isTurboOn = bikeController.IsTurboOn;
    //        currentHealth = bikeController.CurrentHealth;
    //    }
    //}
}
