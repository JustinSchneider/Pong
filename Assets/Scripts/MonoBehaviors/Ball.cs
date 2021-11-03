using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Constants;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isBallActive = false;
    private float moveSpeed = ProjectConstants.BallMoveSpeed;
    private Vector3 lastFrameVelocity;
    private float minVelocity = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PrepForLaunch()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        moveDirection = new Vector3(Random.value < 0.5f ? -1f : 1f, 0,
            Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f));
    }

    public void Update()
    {
        lastFrameVelocity = rb.velocity;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PrepForLaunch();
            Launch();
        }
    }

    public void Freeze()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }
    
    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        rb.velocity = direction * speed;
    }

    public void Launch()
    {
        isBallActive = true;
        rb.AddForce(moveDirection * moveSpeed);
    }

    public void ChangeDirection(Vector3 direction)
    {
        rb.AddForce(direction * moveSpeed);
    }
}
