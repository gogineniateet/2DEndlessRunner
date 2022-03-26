using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public GameObject currentGround;
    public GameObject groundPrefabs;
    private static GroundSpawn instance;

    Stack<GameObject> ground = new Stack<GameObject>();

    public static GroundSpawn Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GroundSpawn>();
            }
            return instance;
        }
    }
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnGround();
        }
    }

    public void SpawnGround()
    {
       if(ground.Count == 0)
        {
            CreateGround(10);
        }
        GameObject temp = ground.Pop();
        temp.SetActive(true);
        temp.transform.position = currentGround.transform.GetChild(0).position;
        currentGround = temp;
    }

    private void CreateGround(int value)
    {
        for (int i = 0; i < value; i++)
        {
            ground.Push(Instantiate(groundPrefabs));
            groundPrefabs.SetActive(false);
        }
    }

    public void BackToGroundPool(GameObject obj)
    {
        ground.Push(obj);
        ground.Peek().SetActive(false);
    }
}
