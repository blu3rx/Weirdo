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
    public float deadOffset = 5f;

    [Header("Transforms")]
    public Transform camera;


    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal") * moveSpeed;

        if (transform.position.y < camera.position.y-deadOffset)
            gameController.Instance.GameOver = true;

    }

    private void FixedUpdate()
    {
        Vector2 velocity = rbody.velocity;
        velocity.x = movement;
        rbody.velocity = velocity;
    }


}
