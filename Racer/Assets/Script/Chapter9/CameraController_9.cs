using UnityEngine;

public class CameraController_9 : MonoBehaviour, SubScriber
{
    private bool isTurboOn = false;
    private Vector3 initialPosition;
    private float shakeMagnitude = 0.1f;
    private BikeController_9 bikeController;

    private void OnEnable()
    {
        initialPosition = gameObject.transform.localPosition;
    }

    private void Start()
    {
        Subscrive(EventType.TurboOn);
        Subscrive(EventType.TakeDamage);
    }

    private void Update()
    {
        if (isTurboOn)
        {
            gameObject.transform.localPosition = initialPosition + (Random.insideUnitSphere * shakeMagnitude);

        }

        else
        {
            gameObject.transform.localPosition = initialPosition;
        }
    }

    public void Subscrive(EventType concernedEvent)
    {
        EventManager.Instance.SubScribeEvent(concernedEvent, this);
    }

    public void RecieveEvent(EventType broadCastedEvent, BikeController_9 publisher)
    {
        switch (broadCastedEvent)
        {
            case EventType.TakeDamage:
                isTurboOn = publisher.IsTurboOn;
                break;

            case EventType.TurboOn:
                isTurboOn = publisher.IsTurboOn;
                break;
        }
    }

    //public override void OnCatchEvent(Subject subject)
    //{
    //    if (!bikeController)
    //        bikeController = subject.GetComponent<BikeController_9>();

    //    if (bikeController)
    //        isTurboOn = bikeController.IsTurboOn;
    //}
}
