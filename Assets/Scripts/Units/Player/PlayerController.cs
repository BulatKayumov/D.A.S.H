using System.Collections;
using UnityEngine;
using DASH._Units;

namespace DASH._Player
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerController : MonoBehaviour
    {
        PlayerCombat combat;
        public float walkingSpeed = 3f;
        public float rollingSpeed = 6f;
        public float runningSpeed = 5f;
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
        RaycastHit hit;
        public Vector3 offset;
        public Transform LookPoint;

        public Camera playerCamera;
        private PlayerAnimator animator;
        CharacterController characterController;
        CharacterStats stats;

        [HideInInspector]
        public bool canMove = true;

        void Start()
        {
            characterController = GetComponent<CharacterController>();
            stats = GetComponent<CharacterStats>();
            // Lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            animator = GetComponent<PlayerAnimator>();
            combat = GetComponent<PlayerCombat>();
        }

        void Update()
        {
            walkingSpeed = stats.speed.GetStat();
            runningSpeed = walkingSpeed * 2;
            rollingSpeed = walkingSpeed * 1.5f;
            if (characterController.isGrounded && canMove)
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);

                bool isRunning = Input.GetKey(KeyCode.LeftShift);

                curSpeedX = (isRolling ? rollingSpeed : (isRunning ? runningSpeed : walkingSpeed)) * Input.GetAxis("Vertical");
                curSpeedY = (isRolling ? rollingSpeed : (isRunning ? runningSpeed : walkingSpeed)) * Input.GetAxis("Horizontal");
                movementDirectionY = moveDirection.y;
                moveDirection = forward * curSpeedX + right * curSpeedY;

                if (Input.GetButton("Jump") && !isRolling)
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
                if (Physics.Linecast(LookPoint.position, LookPoint.position + transform.rotation * offset, out hit))
                {
                    if (Vector3.Distance(LookPoint.position, hit.point) < offset.magnitude)
                    {
                        playerCamera.transform.position = hit.point;
                    }
                    else
                    {
                        playerCamera.transform.localPosition = offset;
                    }
                }
                else
                {
                    playerCamera.transform.localPosition = offset;
                }
            }


            if (Input.GetMouseButtonDown(0))
            {
                combat.Attack();
            }
            if (Time.timeScale == 0)
            {
                canMove = false;
            }
            else
            {
                canMove = true;
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