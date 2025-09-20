using UnityEngine;

public class Drone_11 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private RaycastHit hit;
    private Vector3 razerDir;
    private float razerAngle = -45.0f;
    private float razerDistance = 15.0f;

    public float speed = 1.0f;
    public float maxMovingHeight = 5.0f;
    public float maxMovingWidth = 3.0f;
    public float fallbackDistance = 20.0f;

    void Start()
    {
        razerDir = transform.TransformDirection(Vector3.back) * razerDistance;

        razerDir = Quaternion.Euler(razerAngle, 0.0f, 0f) * razerDir;
    }

    public void ApplyStrategy(IManoeuvreBehaviour strategy)
    {
        strategy.Manoeuvre(this);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, razerDir, Color.blue);

        if(Physics.Raycast(transform.position, razerDir, out hit, razerDistance))
        {
            if(hit.collider)
            {
                Debug.DrawRay(transform.position, razerDir, Color.green);
            }
        }
    }
}
