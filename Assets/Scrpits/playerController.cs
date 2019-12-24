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
    public float switchOffset = 5f;
    public float scoreMultiplair = 10;
    private float count;
    private float time;


    [Header("Transforms")]
    public Transform camera;

    private Vector3 startPos = Vector3.zero;


    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        //Hareket
        movement = Input.GetAxis("Horizontal") * moveSpeed;

        //Gameover
        if (transform.position.y < camera.position.y - deadOffset)
            gameController.Instance.GameOver = true;
        
        //Kamera switch

        Vector3 pos = transform.position;
        if (transform.position.x > camera.position.x + switchOffset)
            pos.x = -switchOffset + 1f;

        if (transform.position.x < camera.position.x - switchOffset)
            pos.x = switchOffset - 1f;

        transform.position = pos;


        //ScoreHesabı

        //Debug.Log(time);

        time += Time.deltaTime;
        count = (transform.position.y - startPos.y)*time;

        if (count > 0 && gameController.Instance.Score < count)
            gameController.Instance.Score = Mathf.RoundToInt(count);



    }

    private void FixedUpdate()
    {
        Vector2 velocity = rbody.velocity;
        velocity.x = movement;
        rbody.velocity = velocity;
    }


}
