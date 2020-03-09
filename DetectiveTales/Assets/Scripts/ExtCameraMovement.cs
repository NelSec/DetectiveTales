using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtCameraMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject[] goalObject = null;

    [SerializeField]
    private Transform goal = null;

    private int currentGoalObject = 0;
    public float speed = 1.0f;

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            
            goal = goalObject[currentGoalObject].transform;
            
            currentGoalObject++;
        }
        transform.position = Vector3.MoveTowards(transform.position, goal.position, step);
    }
}
