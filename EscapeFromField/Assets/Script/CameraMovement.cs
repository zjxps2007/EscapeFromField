using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody;
    
    [SerializeField]
    private Transform cameraArm;

    private Animator _animator;

    private Rigidbody _rigidbody;

    private bool isJump;

    private float jump = 3f;

    private void Awake()
    {
        _animator = playerBody.GetComponent<Animator>();
        _rigidbody = playerBody.GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        move();
    }
    
    void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

         if (x < 180f)
         {
             x = Mathf.Clamp(x, -1f, 70f);
         }
         else
         {
             x = Mathf.Clamp(x, 355f, 361f);
         }
        
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

    void move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        
        _animator.SetBool("IsWalk", isMove);
        if (isMove)
        {
            Vector3 lookFroward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookFroward * moveInput.y + lookRight * moveInput.x;
            
            playerBody.forward = lookFroward;
            transform.position += moveDir * Time.deltaTime * 2f;
        }
        
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            _rigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isJump = true;
        }
    }
    
}
