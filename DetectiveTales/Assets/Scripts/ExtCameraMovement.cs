using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtCameraMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject[] goalObject = null;

    [SerializeField]
    private Transform goal = null;

    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;

    public int currentGoalObject = 0;
    public float speed = 1.0f;

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            switch (currentGoalObject)
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
            }
            goal = goalObject[currentGoalObject].transform;
            
            currentGoalObject++;
        }
        transform.position = Vector3.MoveTowards(
            transform.position, goal.position, step);
    }
}
