﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float acclereationForce = 10;
    private new Rigidbody rigidbody;
    private Vector2 input;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var inputDirection = new Vector3(input.x,0,input.y);
        rigidbody.AddForce(inputDirection * acclereationForce);
    }
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}