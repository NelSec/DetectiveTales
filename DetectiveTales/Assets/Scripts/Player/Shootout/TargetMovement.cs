using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float hValue;
    private float vValue;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        hValue = Input.GetAxis("Horizontal");
        vValue = Input.GetAxis("VerticalComplete");
        Vector3 direction = new Vector3(hValue,vValue,0f);

        rb.velocity = direction * 200f * Time.deltaTime;
    }
}
