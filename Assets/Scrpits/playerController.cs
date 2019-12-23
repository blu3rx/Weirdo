using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class playerController : MonoBehaviour
{
    Rigidbody2D rbody;

    [Header("Floats")]
    private float movement = 0f;
    public float moveSpeed = 2f;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal") * moveSpeed;


    }

    private void FixedUpdate()
    {
        Vector2 velocity = rbody.velocity;
        velocity.x = movement;
        rbody.velocity = velocity;
    }


}
