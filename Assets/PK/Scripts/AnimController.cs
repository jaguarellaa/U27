using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PK.GameJam
{
    public class AnimController : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public void PushAnim()
        {
            animator.SetBool("Push", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Move", false);
            animator.SetBool("MoveBack", false);
        }  
        public void MoveAnim()
        {
            animator.SetBool("Push", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Move", true);
            animator.SetBool("MoveBack", false);

        }

        public void IdleAnim()
        {
            animator.SetBool("Push", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Move", false);
            animator.SetBool("MoveBack", false);

        }
        public void MoveBackAnim()
        {
            animator.SetBool("Push", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Move", false);
            animator.SetBool("MoveBack", true);

        }
    }
}
