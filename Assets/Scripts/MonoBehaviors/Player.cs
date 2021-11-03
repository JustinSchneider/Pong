using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerId;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    
    private Rigidbody rb;
    private readonly float moveSpeed = ProjectConstants.PlayerMoveSpeed;

    private Vector3 moveDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (Input.GetKey(upKey))
        {
            moveDirection = transform.forward;
        } else if (Input.GetKey(downKey))
        {
            moveDirection = -transform.forward;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (moveDirection.sqrMagnitude != 0)
        {
            rb.AddForce(moveDirection * moveSpeed);
        }
    }
}

