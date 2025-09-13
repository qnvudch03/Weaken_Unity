using UnityEngine;

public class BikeController_9 : MonoBehaviour
{
    public bool IsTurboOn {  get; private set; }

    public float CurrentHealth { get; private set; }

    private bool isEngineOn;
    private HUDController_9 hudController;
    private CameraController_9 cameraController;

    [SerializeField]
    private float health = 100.0f;


    private void Awake()
    {
        hudController = gameObject.AddComponent<HUDController_9>();
        cameraController = (CameraController_9)FindObjectOfType(typeof(CameraController_9));
    }

    private void Start()
    {
        StartEngine();

        EventManager.Instance.RegistEvent(EventType.TurboOn, this.ToggleTurbo, this);
        EventManager.Instance.RegistEvent(EventType.TakeDamage, this.TakeDamage, this);

        CurrentHealth = health;
    }

    private void OnEnable()
    {
        //if (hudController)
        //    Attach(hudController);

        //if(cameraController)
        //    Attach(cameraController);
    }

    private void OnDisable()
    {
        //if (hudController)
        //    Detach(hudController);

        //if (cameraController)
        //    Detach(cameraController);
    }

    private void StartEngine()
    {
        isEngineOn = true;
    }

    public void ToggleTurbo()
    {
        if(isEngineOn)
            IsTurboOn = !IsTurboOn;

        EventManager.Instance.OnEventTriggered(EventType.TurboOn);

    }

    //public void TakeDamage(float amount)
    //{
    //    health -= amount;
    //    IsTurboOn = false;


    //    if (health < 0)
    //        Destroy(gameObject);
    //}

    public void TakeDamage()
    {
        health -= 15;
        IsTurboOn = false;
        CurrentHealth = health;

        EventManager.Instance.OnEventTriggered(EventType.TakeDamage);

        if (health < 0)
            Destroy(gameObject);
    }
}
