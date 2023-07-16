using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 5f;
    public float runningSpeed = 8f;
    public float jumpSpeed = 10.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 90.0f;

    private Animator playerAnimator;
    private CharacterController controller;
    private Vector3 movement = Vector3.zero;
    private float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();

        // Lock cursor
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = movement.y;
        movement = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && controller.isGrounded)
        {
            movement.y = jumpSpeed;
            playerAnimator.SetBool("isJumping", true);
        }
        else
        {
            movement.y = movementDirectionY;

        }

        if (!controller.isGrounded)
        {
            movement.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        controller.Move(movement * Time.deltaTime);
        if (movement.x != 0 || movement.z != 0)
        {
            playerAnimator.SetFloat("Velocity", Mathf.Max(Mathf.Abs(movement.x), Mathf.Abs(movement.z)), 0.1f, Time.deltaTime);
        }
        else
        {
            playerAnimator.SetFloat("Velocity", 0f);
        }


        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
