using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharMovementForLoby : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 10f;

    private Rigidbody rb;
    private Animator anim;
    private Vector3 movementInput;
    private float turnInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        turnInput = Input.GetAxisRaw("Horizontal");
        if (movementInput.magnitude == 0)
        {
            anim.SetBool("Move", false);
        }
        else
        {
            anim.SetBool("Move", true);
        }
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = movementInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + transform.TransformDirection(movement));
        
    }

    private void Turn()
    {
        float turnAmount = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}

