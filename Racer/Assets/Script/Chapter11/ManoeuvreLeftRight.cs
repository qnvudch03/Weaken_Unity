using System.Collections;
using UnityEngine;

public class ManoeuvreLeftRight : MonoBehaviour, IManoeuvreBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Manoeuvre(Drone_11 dron)
    {
        StartCoroutine(MoveLeftRight(dron));
    }

    IEnumerator MoveLeftRight(Drone_11 dron)
    {
        float time;
        bool isReverse = false;
        float speed = dron.speed;
        Vector3 startPosition = dron.transform.position;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z + dron.maxMovingWidth);

        while (true)
        {
            time = 0;
            Vector3 start = dron.transform.position;
            Vector3 end = (isReverse) ? startPosition : endPosition;

            while (time < speed)
            {
                dron.transform.position = Vector3.Lerp(start, end, time / speed);
                time += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
