using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Jump : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    public float gravity = -9.81f, jumpForce = 3f;
    private float yVar;

    public IntData playerJumpCount;
    private int jumpCount;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
        {
            yVar = jumpForce;
            jumpCount++;
        }

        movement.y = yVar;
        controller.Move(movement * Time.deltaTime);
        yVar += gravity * Time.deltaTime;
    }
}
