using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DASH._Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private const float locomotionAnimationSmoothTime = .1f;
        private float speedPercent;
        private float yVelocity;

        private Animator animator;
        CharacterController characterController;
        private PlayerController playerController;

        string[] attacks = { "Attack1", "Attack2", "Attack3" };

        void Start()
        {
            animator = GetComponentInChildren<Animator>();
            characterController = GetComponent<CharacterController>();
            playerController = GetComponent<PlayerController>();
        }

        void Update()
        {
            speedPercent = characterController.velocity.magnitude / playerController.walkingSpeed;
            animator.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);

            yVelocity = characterController.velocity.y;
            animator.SetFloat("yVelocity", yVelocity, .1f, Time.deltaTime);

            animator.SetBool("isGrounded", characterController.isGrounded);
        }
        public void PlayRandomAttackAnimation()
        {
            animator.SetTrigger(attacks[Random.Range(0, 3)]);
        }

        public void Jump()
        {
            animator.SetTrigger("Jump");
        }

        public void Roll()
        {
            animator.SetTrigger("Roll");
        }

        public void PlayDeathAnimation()
        {
            animator.SetTrigger("Dead");
        }
    }
}