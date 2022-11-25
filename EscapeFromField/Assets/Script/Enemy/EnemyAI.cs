using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private GameObject Prefab;
    [SerializeField] private Transform[] mTfWayPoint = null; //적이 순찰할 위치
    // [SerializeField] private GameObject hpBer;
    // [SerializeField] private Vector3 hpBarOffset = new Vector3(0, 2.2f, 0);

    private Canvas uiCanvas;
    private Image hpBarImage;
    
    private NavMeshAgent _mEnemy;

    private Animator _animator; //적 애니메이션

    private int _mCount; //순찰한 갯수

    private int EnemyHp = 100;

    private bool isdead = false;

    private bool isDamage = false;

    private static readonly int IsWalk = Animator.StringToHash("IsWalk");

    private void Awake()
    {
        _mEnemy = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveToNextWayPoint", 0f, 2f);
        // SetHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHp <= 0 && !isdead)
        {
            _mEnemy.isStopped = true;
            isdead = true;
            _animator.SetTrigger("Is");
            GetComponent<CapsuleCollider>().enabled = false;
            Instantiate(Prefab, transform.position, transform.rotation);
            PlayerCtrl.score += 1;
            //hpBarImage.GetComponentsInParent<Image>()[1].color = Color.clear;
        }
        _animator.SetBool(IsWalk, _mEnemy.velocity != Vector3.zero);
    }
    
    void MoveToNextWayPoint()
    {
        if (!isdead)
        {
            if (_mEnemy.velocity == Vector3.zero)
            {
                _mEnemy.SetDestination(mTfWayPoint[_mCount++].position);

                if (_mCount >= mTfWayPoint.Length)
                {
                    _mCount = 0;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyHp -= 25;
            Debug.Log(EnemyHp);
        }
    }
    

    // void SetHpBar()
    // {
    //     uiCanvas = GameObject.Find("EnemyUI").GetComponent<Canvas>();
    //     GameObject hpBar = Instantiate<GameObject>(hpBer, uiCanvas.transform);
    //     hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];
    //
    //     var _hpbar = hpBar.GetComponent<EnemyHpBar>();
    //     _hpbar.target = transform;
    //     _hpbar.offset = hpBarOffset;
    // }
}
