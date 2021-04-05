using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour


{
    private const float locomotionAnimationSmoothTime = .1f;
    private Animator animator;
    CharacterController _characterController;
    private PlayerController _playerController;
    string[] attacks = {"Attack1", "Attack2", "Attack3"}; 

    public bool isGrounded;

    public bool Move;
    public void PlayRandomAttackAnimation()
    {
        animator.SetTrigger(attacks[UnityEngine.Random.Range(0, 3)]);
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _characterController = GetComponent<CharacterController>();
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = _characterController.velocity.magnitude / _playerController.walkingSpeed;
        animator.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);
        bool attackPressed = Input.GetMouseButtonDown(0);
        bool isRolling = Input.GetKey(KeyCode.LeftControl);
    }
}
