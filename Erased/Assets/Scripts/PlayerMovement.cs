using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 move;
    private float speed = 100f;
    private float xMove;
    private float yMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = Vector2.zero;
    }

    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        move = new Vector2(xMove, yMove);

        rb.AddForce(move * speed * Time.deltaTime);
    }
}
