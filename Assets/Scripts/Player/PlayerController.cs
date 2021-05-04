using System.Collections;
using UnityEngine;

namespace DASH.Player
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerController : MonoBehaviour
    {
        PlayerCombat combat;
        public float walkingSpeed = 5f;
        public float rollingSpeed = 10f;
        public float runningSpeed = 7f;
        public float jumpSpeed = 5.0f;
        public float gravity = 10f;
        public float lookSpeed = 2.0f;
        public float lookXLimit = 45.0f;
        private float rollTime = 1f;
        public bool isRolling = false;
        Vector3 moveDirection = Vector3.zero;
        float rotationX = 0;
        float movementDirectionY;
        float curSpeedX = 0f;
        float curSpeedY = 0f;

        public Camera playerCamera;
        private PlayerAnimator animator;
        CharacterController characterController;

        [HideInInspector]
        public bool canMove = true;

        void Start()
        {
            characterController = GetComponent<CharacterController>();
            // Lock cursor
           //  Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            animator = GetComponent<PlayerAnimator>();
            combat = GetComponent<PlayerCombat>();
        }

        void Update()
        {
            if (characterController.isGrounded && canMove && !isRolling)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);

                bool isRunning = Input.GetKey(KeyCode.LeftShift);

                curSpeedX = (isRolling ? rollingSpeed : (isRunning ? runningSpeed : walkingSpeed)) * Input.GetAxis("Vertical");
                curSpeedY = (isRolling ? rollingSpeed : (isRunning ? runningSpeed : walkingSpeed)) * Input.GetAxis("Horizontal");
                movementDirectionY = moveDirection.y;
                moveDirection = forward * curSpeedX + right * curSpeedY;

                if (Input.GetButton("Jump"))
                {
                    animator.Jump();
                    moveDirection.y = jumpSpeed;
                }
                else
                {
                    moveDirection.y = movementDirectionY;
                }
                characterController.Move(moveDirection * Time.deltaTime);
            }
            else
            {
                moveDirection.y -= gravity * Time.deltaTime;
                characterController.Move(moveDirection * Time.deltaTime);
            }

            // rolling
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (!isRolling && characterController.isGrounded)
                {
                    StartCoroutine("Roll");
                }
            }

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }

            if (Input.GetMouseButtonDown(0))
            {
                combat.Attack();
            }
        }

        private IEnumerator Roll()
        {
            isRolling = true;
            animator.Roll();
            yield return new WaitForSecondsRealtime(rollTime);
            isRolling = false;
        }
    }
}