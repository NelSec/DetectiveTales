﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtCameraMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject[] goalObject = null;

    [SerializeField]
    private Transform goal = null;

    private Transform previousGoal = null;

    public GameObject transition;
    public GameObject transition2;
    public GameObject transition3;
    public GameObject transition4;
    public GameObject transition5;
    public GameObject transition6;

    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;
    public Animator animator5;
    public Animator animator6;

    public int currentGoalObject = 0;
    public int previousGoalObject;
    public float speed = 1.0f;

    void Update()
    {
        previousGoalObject = currentGoalObject - 1;
        float step = speed * Time.deltaTime;

        if(Input.GetKeyDown("space") && currentGoalObject < 1)
        {
            goal = goalObject[currentGoalObject].transform;

            currentGoalObject++;
        }
        else if (
            Input.GetKeyDown("space") && transition.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition2.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition3.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition4.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition5.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition6.GetComponent<Interactive>().toTransition == true)
        {
            /*switch (currentGoalObject)
            {
                case (1):
                    animator.SetTrigger("FadeOut");
                    break;
                case (2):
                    animator2.SetTrigger("FadeOut2");
                    break;
                case (3):
                    animator3.SetTrigger("FadeOut3");
                    break;
                case (4):
                    animator4.SetTrigger("FadeOut4");
                    break;
                case (5):
                    animator5.SetTrigger("FadeOut5");
                    break;
                case (6):
                    animator6.SetTrigger("FadeOut6");
                    break;
            }*/
            goal = goalObject[currentGoalObject].transform;

            currentGoalObject++;

            if (previousGoalObject >= 0)
            {
                previousGoal = goalObject[previousGoalObject].transform;
            }
        }
        transform.position = Vector3.MoveTowards(
            transform.position, goal.position, step);
    }
}
