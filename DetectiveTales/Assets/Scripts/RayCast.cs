using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 direction;

    private float rayDistance;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        rayDistance = 100f;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        direction = targetTransform.position - transform.position;

        Debug.DrawRay(transform.position, direction * rayDistance, Color.magenta);

        if (Physics.Raycast(transform.position, direction * rayDistance, out hit, rayDistance) && hit.transform.tag == "Enemy" && Input.GetKeyDown("space"))
        {
            Destroy(hit.transform.gameObject);
        }
    }
}
