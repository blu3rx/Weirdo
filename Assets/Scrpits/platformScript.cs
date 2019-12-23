using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    [Header("Floats")]
    public float jumpForce = 10f;

    [Header("Transforms")]
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player.transform.position.y > transform.position.y + 5f)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rbody = collision.collider.GetComponent<Rigidbody2D>();

            if (rbody != null)
            {
                Vector2 velocity = rbody.velocity;
                velocity.y = jumpForce;
                rbody.velocity = velocity;
            }
        }


    }
}
