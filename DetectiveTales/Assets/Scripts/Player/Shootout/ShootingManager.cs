using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject scene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!RayCast.instance.allKilled && RayCast.instance.timeLeft < 0)
        {
            Destroy(GameObject.Find("test_shooting_scene01"));
            Destroy(GameObject.Find("test_shooting_scene01(Clone)"));
            Instantiate(scene);
        }

    }
}
