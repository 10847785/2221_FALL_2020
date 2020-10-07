using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private FloatData moveSpeed;
    public FloatData normalSpeed, fastSpeed;
    public float rotateSpeed = 30f, gravity = -9.81f;

    private CharacterController controller;
    private Vector3 movement;
    private float yVar;
    private bool canMove = true;

    private void Start()
    {
        moveSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
        StartCoroutine(Move());
    }
    
    private readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private IEnumerator Move()
    {
        canMove = true;
        while (canMove)
        {
            yield return wffu;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = fastSpeed;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = normalSpeed;
            }

            if (controller.isGrounded && movement.y < 0)
            {
                yVar = -1f;
            }
        
            var hInput = Input.GetAxis("Horizontal") * Time.deltaTime*rotateSpeed;
            transform.Rotate(0, hInput, 0);
            var vInput = Input.GetAxis("Vertical") * moveSpeed.value;
            movement.Set(vInput, yVar, 0);

            movement = transform.TransformDirection(movement);
            controller.Move(movement * Time.deltaTime);
            yVar += gravity * Time.deltaTime;
        }
        
    }
}
