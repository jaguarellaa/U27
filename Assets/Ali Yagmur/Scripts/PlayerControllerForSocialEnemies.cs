using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerForSocialEnemies : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject characterModel;

    private void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        float horizontalInputRB = Input.GetAxis("Horizontal");
        float verticalInputRB = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInputRB, 0f, verticalInputRB).normalized;
        if (moveDirection.magnitude != 0f)
        {
            rb.velocity = moveDirection * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        
        //rb.AddForce(moveDirection * speed, ForceMode.Impulse);
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        

        characterModel.transform.localPosition = Vector3.zero;

        if (movementDirection.magnitude != 0)
        {
            animator.SetBool("Move", true);
            float angle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
        else
        {
            animator.SetBool("Move", false);
        }

        movementDirection.Normalize();

        Vector3 movementAmount = movementDirection * speed * Time.deltaTime;

        //transform.position += new Vector3(movementAmount.x, 0, movementAmount.z);
    }

    public void GetDamage(int timeLost)
    {
        Debug.Log("You have lost " + timeLost + " seconds!");
    }

    public void GetAcademyPoints(int points)
    {
        Debug.Log("You have gained " + points + " points!");
    }
}
