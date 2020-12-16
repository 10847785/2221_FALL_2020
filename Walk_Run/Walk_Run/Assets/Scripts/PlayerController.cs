using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
   /* public float rotateSpeed = 120f, gravity = -9.81f, jumpForce = 10f;
    public FloatData normalSpeed, fastSpeed;
    public IntData playerJumpCount;

    private float yVar;
    private int jumpCount;

    protected CharacterController controller;
    protected Vector3 movement;
    protected bool canMove = true;
    protected readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    protected float vInput, hInput;
    protected FloatData moveSpeed;

    private void OnEnable()
    {
        moveSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
        StartCoroutine(Move());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    protected IEnumerator Move()
    {
        canMove = true;
        while (canMove)
        {
            OnMove();
            yield return wffu;
        }
    }

    protected virtual void OnHorizontal()
    {
        hInput = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        transform.Rotate(0, hInput, 0);
    }

    protected virtual void OnVertical()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed.value;
        movement.Set(vInput, yVar, 0);
    }
    
    private void OnMove()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = fastSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalSpeed;
        }
        
        OnHorizontal();
        OnVertical();

        yVar += gravity * Time.deltaTime;
        
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
        
        movement = transform.TransformDirection(movement);
        controller.Move(movement * Time.deltaTime);
    } */
   
    private CharacterController controller;
    private Vector3 movement;
    public Vector3 lookDirection, finalDirection;
    private float yVar;
    //private bool canMove = true; //canJump = true, canSprint = true;
    public float gravity = -9.81f;
    public FloatData normalSpeed, fastSpeed, jumpForce;
    private FloatData currentSpeed;
    public IntData playerJumpMax;
    private int jumpCount;
    public float pushForce;
    public float waitTime;
    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private WaitForSeconds wfs;

    private void Start()
    {
        currentSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
        wfs = new WaitForSeconds(waitTime);
    }

    private void Update()
    {
        //canMove = true;
        
            yVar += gravity * Time.deltaTime;
            var vInput = Input.GetAxis("Vertical") * currentSpeed.value * Time.deltaTime;
            var hInput = Input.GetAxis("Horizontal") * currentSpeed.value * Time.deltaTime;
            if (controller.isGrounded && movement.y < 0)
            {
                yVar = -1;
                jumpCount = 0;
            }

            if (Input.GetButtonDown("Jump") && jumpCount < playerJumpMax.value)
            {
                yVar = jumpForce.value;
                jumpCount++;
            }

            if (Input.GetButton("Fire3"))
            {
                currentSpeed = fastSpeed;
            }
            else if (Input.GetButtonUp("Fire3"))
            {
                currentSpeed = normalSpeed;
            }

            lookDirection.Set(hInput, 0, vInput);
            if (hInput > 0.05f || hInput < -0.05f || vInput > 0.05f || vInput < -0.05f)
            {
                finalDirection.Set(lookDirection.x, 0, lookDirection.z);
            }

            if (lookDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(finalDirection);
            }

            movement.Set(hInput, yVar, vInput);
            controller.Move(movement);
        
    }

    private IEnumerator KnockBack(ControllerColliderHit hit, Rigidbody rBody)
    {
        //canMove = false;
        var pushDistance = 2f;
        movement = -hit.moveDirection;
        movement.y = -1;
        while (pushDistance > 0)
        {
            yield return wffu;
            pushDistance -= 0.1f;
            controller.Move(movement * Time.deltaTime);
            var pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            var forces = pushDirection * pushForce;
            rBody.AddForce(forces);
        }

        movement = Vector3.zero;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var rbody = hit.collider.attachedRigidbody;
        if (rbody == null || rbody.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        StartCoroutine(KnockBack(hit, rbody));
    } 
}
