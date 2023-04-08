using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

namespace PK.GameJam
{
    public class PK_BasicMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;

        private CharacterController _characterController;
        private float _speed;
        private AnimController animController;

        private void Awake()
        {
           _characterController= GetComponent<CharacterController>();
            animController = GetComponent<AnimController>();
            _speed = speed;
        }
       

        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 moveDrection =new Vector3 (0,0,z);
            _characterController.Move(transform.TransformDirection(moveDrection)*_speed*Time.deltaTime);
            transform.Rotate(0, x*rotateSpeed*Time.deltaTime, 0);
            RaycastHit hit;
            if(!Physics.Raycast(transform.position,transform.forward,out hit, .9f))
            {
                _speed = speed;
                if (z > 0) animController.MoveAnim();
                else if(Mathf.Approximately(z,0)) animController.IdleAnim();
                else animController.MoveBackAnim();
                
            }

        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.rigidbody == null) return;
            if (hit.moveDirection.y < -.3f) return;
            float push = speed / hit.collider.attachedRigidbody.mass;
            hit.collider.attachedRigidbody.velocity = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z) * push;
            _speed = push;
            if (_characterController.velocity.magnitude > 0) animController.PushAnim();
            else animController.IdleAnim();

        }
        
    }
}
