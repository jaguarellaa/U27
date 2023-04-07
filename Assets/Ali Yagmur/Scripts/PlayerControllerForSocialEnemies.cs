using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerForSocialEnemies : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        movementDirection.Normalize();

        Vector3 movementAmount = movementDirection * speed * Time.deltaTime;

        transform.position += new Vector3(movementAmount.x, 0, movementAmount.z);
    }

    public void GetDamage(int timeLost)
    {
        Debug.Log("You have lost " + timeLost + " seconds!");
    }
}
