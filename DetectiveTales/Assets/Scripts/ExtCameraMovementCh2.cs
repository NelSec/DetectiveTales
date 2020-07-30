﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtCameraMovementCh2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] goalObject = null;

    [SerializeField]
    private Transform goal = null;

    //private Transform previousGoal = null;

    /*public GameObject transition;
    public GameObject transition2;
    public GameObject transition3;
    public GameObject transition4;
    public GameObject transition5;
    public GameObject transition6;*/

    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;
    public Animator animator5;
    public Animator animator6;
    public Animator animator7;
    public Animator animator8;
    public Animator animator9;
    public Animator animator10;
    public Animator animator11;
    public Animator animator12;

    public AudioSource ambient;
    public AudioSource engine;

    public int currentGoalObject = 0;
    //public int previousGoalObject;
    public float speed = 1.0f;

    void Update()
    {
        //previousGoalObject = currentGoalObject - 1;
        float step = speed * Time.deltaTime;

        /*if(Input.GetKeyDown("space") && currentGoalObject < 1)
        {
            goal = goalObject[currentGoalObject].transform;

            currentGoalObject++;
        }*/
        if (
            Input.GetKeyDown("l") /*&& SceneController.instance.objetiveDone /*&& transition.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition2.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition3.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition4.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition5.GetComponent<Interactive>().toTransition == true ||
            Input.GetKeyDown("space") && transition6.GetComponent<Interactive>().toTransition == true*/)
        {
            switch (currentGoalObject)
            {
                case (0):
                    animator.SetTrigger("FadeOut");
                    ambient.Play();
                    engine.Play();
                    break;
                case (1):
                    animator2.SetTrigger("FadeOut2");
                    break;
                case (2):
                    animator3.SetTrigger("FadeOut3");
                    ambient.Stop();
                    engine.Stop();
                    break;
                case (3):
                    animator4.SetTrigger("FadeOut4");
                    break;
                /*case (4):
                    animator5.SetTrigger("FadeOut5");
                    break;
                case (5):
                    animator6.SetTrigger("FadeOut6");
                    break;
                case (6):
                    animator7.SetTrigger("FadeOut7");                    
                    break;
                case (7):
                    animator8.SetTrigger("FadeOut8");                   
                    break;
                case (8):
                    animator9.SetTrigger("FadeOut9");
                    break;
                case (9):
                    animator10.SetTrigger("FadeOut10");
                    break;
                case (10):
                    animator11.SetTrigger("FadeOut11");
                    break;
                case (11):
                    animator12.SetTrigger("FadeOut12");
                    break;*/
            }

            if (currentGoalObject >= goalObject.Length)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            goal = goalObject[currentGoalObject].transform;

            currentGoalObject++;

            /*if (previousGoalObject >= 0)
            {
                previousGoal = goalObject[previousGoalObject].transform;
            }*/
        }
        else if (Input.GetKeyDown("m"))
            SceneManager.LoadScene("Menu");

        transform.position = Vector3.MoveTowards(
            transform.position, goal.position, step);
    }
}