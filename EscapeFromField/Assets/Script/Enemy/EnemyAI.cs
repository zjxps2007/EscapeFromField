using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private GameObject Prefab;
    
    private NavMeshAgent _mEnemy;

    private Animator _animator; //적 애니메이션

    private int _mCount; //순찰한 갯수

    private int EnemyHp = 100;

    private bool isdead = false;
    
    
    
    [SerializeField]
    private Transform[] mTfWayPoint = null; //적이 순찰할 위치

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
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHp <= 0 && !isdead)
        {
            _mEnemy.Stop();
            isdead = true;
            _animator.SetTrigger("Is");
            GetComponent<CapsuleCollider>().enabled = false;
            Instantiate(Prefab, transform.position, transform.rotation);
            PlayerCtrl.score += 1;
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
            EnemyHp -= 10;
            Debug.Log(EnemyHp);
        }
    }
}
