using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private static GameManager instance;

    public static GameManager GetInstance()
    {
        {
            if (instance == null)
            {
                // 씬에서 GameManager 찾기
                instance = FindFirstObjectByType<GameManager>();

                // 없으면 새 GameObject 생성
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Dictionary<int, Dictionary<COLLISIONTYPE, Action>> collideEvents;

    public void RegisteBikeColide(int bikeId, COLLISIONTYPE type, Action action)
    {
        collideEvents[bikeId][type] = action;
    }
}
