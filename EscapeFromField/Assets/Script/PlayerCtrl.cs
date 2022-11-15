using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float _speed; // 플레이어 속도
    private readonly float _jump = 5.0f; // 점프 높이
    private bool isJump = false; // 점프 상태

    private Animator anim; // 플레이어 에니메이션
    private Vector3 _movDir; //플레이어 이동
    private GameObject _weaponObject; // 무기 교체

    private CharacterController _characterController;
    private static readonly int IsRun = Animator.StringToHash("IsRun");
    private static readonly int IsWalk = Animator.StringToHash("IsWalk");

    private float yVel;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _movDir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!OnInventory.inventoryActivated)
        {
            Move();
            SetAnimator();
        }
    }

    private void SetAnimator() // 플레이어 에니메이션
    {
        _movDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        anim.SetBool(IsWalk, _movDir != Vector3.zero);

        if (Input.GetKey(KeyCode.LeftShift) && _movDir != Vector3.zero) // 달리기
        {
            _speed = 3.0f;
            anim.SetBool(IsRun, true);
        }
        else
        {
            _speed = 2.0f;
            anim.SetBool(IsRun, false);
        }
    }

    private void Move() //플레이어 이동
    {
        _movDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Camera.main != null)
        {
            var offset = Camera.main.transform.forward;
            offset.y = 0;
            transform.LookAt(transform.position + offset);
        }

        _movDir = transform.TransformDirection(_movDir).normalized * _speed;
        Jump();
        _characterController.Move(_movDir * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;
            yVel = _jump;
        }
        if (_characterController.isGrounded)
        {
            isJump = false;
            yVel = 0;
        }
        _movDir.y = yVel;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            _weaponObject = other.gameObject;
        }
        Debug.Log(_weaponObject.name);
    } 
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            _weaponObject = null;
        }
    }
    

    private void Interation()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_weaponObject.CompareTag("Weapon"))
            {
                
            }
        }
    }
}
