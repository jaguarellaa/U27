using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

namespace PK.GameJam
{
    public class PK_BasicMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;

        private CharacterController _characterController;
        private float _speed;

        private void Awake()
        {
           _characterController= GetComponent<CharacterController>();
            _speed = speed;
        }
       

        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 moveDrection =new Vector3 (0,0,z);
            _characterController.Move(transform.TransformDirection(moveDrection)*_speed*Time.deltaTime);
            transform.Rotate(0, x*rotateSpeed*Time.deltaTime, 0);

        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.rigidbody == null) return;
            if (hit.moveDirection.y < -.3f) return;
            float push = speed / hit.collider.attachedRigidbody.mass;
            hit.collider.attachedRigidbody.velocity = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z) * push * Time.deltaTime;
            _speed = push;
        }
        private void OnCollisionExit(Collision collision)
        {
            _speed = speed;
        }
    }
}
