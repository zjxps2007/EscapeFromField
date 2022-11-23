using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public static int score = 0;
    
    //플레이어 체력 및 마나 텍스트
    [SerializeField] 
    private Text hpText;
    [SerializeField] 
    private Text mpText;
    
    //플레이어 체력 및 마나 이미지
    [SerializeField] 
    private Image hpImage;
    [SerializeField] 
    private Image mpImage;

    [SerializeField]
    private Text Kill;

    private float _speed; // 플레이어 속도
    private readonly float _jump = 4.5f; // 점프 높이
    private bool _isJump = false; // 점프 상태
    private float _yVelocity; //점프속도?
    
    //체력 또는 마나 관리 타이머
    private float _mpTimer = 2f;

    //플레이어의 체력 관리
    private float hpPoint = 50;
    private float maxHpPoint = 100;
    //플레이어 마나 관리
    private float _mpPoint = 50;
    private float _maxMpPoint = 100;

    private Animator _anim; // 플레이어 에니메이션
    private Vector3 _movDir; //플레이어 이동
    private GameObject _weaponObject; // 무기 교체

    private CharacterController _characterController; //캐릭터 컨트롤러
    
    //에니메이션
    private static readonly int IsRun = Animator.StringToHash("IsRun");
    private static readonly int IsWalk = Animator.StringToHash("IsWalk");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
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
        Move();
        SetAnimator();
        UpdateGraphics();
    }

    private void SetAnimator() // 플레이어 에니메이션
    {
        _mpTimer += Time.deltaTime;
        _movDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _anim.SetBool(IsWalk, _movDir != Vector3.zero);

        if (Input.GetKey(KeyCode.LeftShift) && _movDir != Vector3.zero && _mpPoint > 0) // 달리기
        {
            if (_mpTimer >= 0.3f)
            {
                _mpPoint -= 1f;
                _mpTimer = 0;
            }
            _speed = 3.0f;
            _anim.SetBool(IsRun, true);
        }
        else
        {
            if (_movDir == Vector3.zero && !_isJump)
            {
                if (_mpPoint < _maxMpPoint)
                {
                    if (_mpTimer >= 0.2f)
                    {
                        _mpPoint += 1;
                        _mpTimer = 0;
                    }
                }
            }
            _speed = 2.0f;
            _anim.SetBool(IsRun, false);
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
        if (Input.GetKeyDown(KeyCode.Space) && !_isJump && _mpPoint > 0)
        {
            _isJump = true;
            _yVelocity = _jump;
            _mpPoint -= 10f;
            if (_mpPoint - 10 <= 0)
            {
                _mpPoint = 0;
            }
        }
        if (_characterController.isGrounded)
        {
            _isJump = false;
            _yVelocity = 0;
        }
        _movDir.y = _yVelocity;
    }
    
    void PlayHealthUI()
    {
        float ratio = hpPoint / maxHpPoint;
        hpImage.rectTransform.localPosition = new Vector3(hpImage.rectTransform.rect.width * ratio - hpImage.rectTransform.rect.width, 0, 0);
        hpText.text = hpPoint.ToString("0") + "/" + maxHpPoint.ToString("0");
    }
    
    void PlayManaUI()
    {
        float ratio = _mpPoint / _maxMpPoint;
        mpImage.rectTransform.localPosition = new Vector3(mpImage.rectTransform.rect.width * ratio - mpImage.rectTransform.rect.width, 0, 0);
        mpText.text = _mpPoint.ToString("0") + "/" + _maxMpPoint.ToString("0");
    }

    void UpdateGraphics()
    {
        PlayHealthUI();
        PlayManaUI();
        ShowView();
    }

    void ShowView()
    {
        Kill.text = score.ToString();
    }
    
    //체력 회복
    public void IncreaseHP(int _heal)
    {
        hpPoint += _heal;
        if (hpPoint > maxHpPoint)
        {
            hpPoint = maxHpPoint;
        }
    }

    //지연회복 구현 ??
    public void IncreaseSlowHP(int _heal)
    {
        
    }

    //마나 회복
    public void IncreaseMP(int Heal)
    {
        _mpPoint += Heal;
        if (_mpPoint > _maxMpPoint)
        {
            _mpPoint = _maxMpPoint;
        }
    }
    
    // 최대 체력 증가
    public void IncreaseMaxHP(float Heal)
    {
        maxHpPoint += (int) (maxHpPoint * Heal / 100);
    }
    
    // 최대 마나 증가
    public void IncreaseMaxMP(float Mana)
    {
        _maxMpPoint += (int) (_maxMpPoint * Mana / 100);
    }
}

/*
 캐릭터 컨트롤러 충돌검사 방법
 OnTriggerEnter - 가만히 있는 물체를 충돌검사 할때
 OnControllerColliderHit - 이동중에 충돌검사 할때
*/