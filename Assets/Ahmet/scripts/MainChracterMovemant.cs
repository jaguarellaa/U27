using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PK.GameJam
{
    public class MainChracterMovemant : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;

        private CharacterController _characterController;
        private AnimController animController;
        private float _speed;
        private Vector3 playerVelocity;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            animController = GetComponent<AnimController>();
            _speed = speed;
        }


        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 moveDrection = transform.forward * z;
            if (_characterController.isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            transform.Rotate(Vector3.up * x * Time.deltaTime * rotateSpeed);
            _characterController.Move(moveDrection * _speed * Time.deltaTime);
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, transform.forward, out hit, .9f))
            {
                _speed = speed;
                if (moveDrection.magnitude > 0) animController.MoveAnim();
                else if (Mathf.Approximately(moveDrection.magnitude, 0)) animController.IdleAnim();
                else animController.MoveBackAnim();
            }
            else
            {
                if (moveDrection.magnitude > 0 && hit.collider.CompareTag(TagContainer.PushObjectTag)) animController.PushAnim();
                else if (moveDrection.magnitude > 0) animController.MoveAnim();
                else if (moveDrection.magnitude < 0) animController.MoveBackAnim();
                else animController.IdleAnim();
            }
            playerVelocity.y += -9.81f * Time.deltaTime;
            _characterController.Move(playerVelocity * Time.deltaTime);

        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.rigidbody == null) return;
            if (hit.moveDirection.y < -.3f) return;
            float push = speed / hit.collider.attachedRigidbody.mass;
            hit.collider.attachedRigidbody.velocity = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z) * push;
            _speed = push;



        }
    }
}
