using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private FloatData moveSpeed;
    public FloatData normalSpeed, fastSpeed;
    public float rotateSpeed = 120, gravity = -9.81f;
 
    private CharacterController controller;
    private Vector3 movement;
    private float yVar;
    private void Start()
    {
        moveSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
       
    }

    private void Update()
    {
        var hInput = Input.GetAxis("Horizontal")*Time.deltaTime*rotateSpeed;
        transform.Rotate(0,hInput,0);
        
        var vInput = Input.GetAxis("Vertical")*moveSpeed.value;
        movement.Set(vInput, yVar, 0);
        
       
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
        
        movement = transform.TransformDirection(movement);
        controller.Move(movement * Time.deltaTime);
    }
}
