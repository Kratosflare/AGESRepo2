using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float acclerationForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    private PhysicMaterial stoppingPhysicMaterial, movingPhysicMaterial;

    private new Rigidbody rigidbody;
    public Vector2 input;
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
            rigidbody.AddForce(inputDirection * acclerationForce, ForceMode.Acceleration);
        }
     
    }


   public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

}
