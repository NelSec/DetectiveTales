using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Collider collider;

    public GameObject firstObjectHide;
    public GameObject secondObjectHide;

    public GameObject firstObjectShow;
    public GameObject secondObjectShow;

    void Start()
    {
        OnTriggerEnter(collider);
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (collider.CompareTag ("Player"))
        {
            if (firstObjectHide != null)
                firstObjectHide.SetActive(false);

            if (secondObjectHide != null)
                secondObjectHide.SetActive(false);

            if (firstObjectShow != null)
                firstObjectShow.SetActive(true);

            if (secondObjectShow != null)
                secondObjectShow.SetActive(true);
        }

    }
}
