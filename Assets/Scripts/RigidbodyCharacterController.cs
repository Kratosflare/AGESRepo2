﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float acclereationForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    private PhysicMaterial stoppingPhysicMaterial, movingPhysicMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }
    private void FixedUpdate()
    {

        var inputDirection = new Vector3(input.x,0,input.y);

        if (inputDirection.magnitude > 0)
        {
            collider.material = movingPhysicMaterial;
        }
        else
        {
            collider.material = stoppingPhysicMaterial;
        }

        if (rigidbody.velocity.magnitude<maxSpeed)
        {
            rigidbody.AddForce(inputDirection * acclereationForce, ForceMode.Acceleration);
        }
     
    }
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
