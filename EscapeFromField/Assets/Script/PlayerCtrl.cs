using System;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float speed = 1f; // 플레이어 속도
    private float jump = 3f; // 점프 높이
    //private bool isJump = false; // 점프 상태

    private Animator anim; // 플레이어 에니메이션
    private Vector3 movDir;
    private GameObject weaponObject; // 무기 교체
    private Rigidbody _rigidbody;

    private CharacterController _characterController;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        movDir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SetAnimator();
        Jump();
    }

    private void SetAnimator() // 플레이어 에니메이션
    {
        movDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movDir != Vector3.zero) {
            anim.SetBool("IsWalk",true);
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && movDir != Vector3.zero) // 달리기
        {
            speed = 2.0f;
            anim.SetBool("IsRun", true);
        }
        else
        {
            speed = 1.0f;
            anim.SetBool("IsRun", false);
        }
    }

    private void Move() //플레이어 이동
    {
        movDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Camera.main != null)
        {
            var offset = Camera.main.transform.forward;
            offset.y = 0;
            transform.LookAt(transform.position + offset);
        }

        movDir = transform.TransformDirection(movDir).normalized;
        _characterController.Move(movDir * speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movDir.y = jump;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            //isJump = false;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            weaponObject = other.gameObject;
        }
        Debug.Log(weaponObject.name);
    } 
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            weaponObject = null;
        }
    }
    

    private void Interation()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (weaponObject.CompareTag("Weapon"))
            {
                
            }
        }
    }
}
