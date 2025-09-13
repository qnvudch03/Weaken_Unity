using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCenter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private readonly List<BikeController_9> bikeControllers = new List<BikeController_9>();

    //�߰��� �÷��̾� ������ ���ٴ� ��ü�Ͽ�, ���� Ž���� ������ HastSet��� "�����ϸ� �̰� ����" C++�� Vector �� ���뼺�̴�
    private readonly HashSet<BikeController_9> bikecontrollers = new HashSet<BikeController_9>();
    private readonly HashSet<CameraController_9> cameracontrolles = new HashSet<CameraController_9>();
    void Start()
    {
        var controllers =  FindObjectsByType<BikeController_9>(FindObjectsSortMode.None);
        int numControllers = controllers.Length;
        float camwidth = 1.0f / numControllers;

        for (int i = 0; i < numControllers; i++)
        {
            var controller = controllers[i];
            GameObject Bike = controller.gameObject;
            GameObject CamObj = new GameObject("FollowCamera");

            CamObj.transform.SetParent(Bike.transform);
            CamObj.transform.localPosition = new Vector3(0, 0, -20);

            Camera cam = CamObj.AddComponent<Camera>();
            cam.AddComponent<CameraController_9>();

            cam.rect = new Rect(i * camwidth, 0, camwidth, 1);
            

            bikecontrollers.Add(controller);
        }

        //int numControllers = controllers.Length;
        //int count = 1;
        //foreach (var controller in controllers)
        //{
        //    GameObject Bike = controller.gameObject;

        //    Camera cam = Bike.AddComponent<Camera>();
        //    cam.AddComponent<CameraController_9>();
        //    cam.rect

        //    bikecontrollers.Add(controller);


        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
