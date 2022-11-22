using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _mEnemy;

    private Animator _animator; //적 애니메이션
    
    private int _mCount; //순찰한 갯수
    
    [SerializeField]
    private Transform[] mTfWayPoint = null; //적이 순찰할 위치
    [SerializeField] 
    private float m_angle = 0f;
    [SerializeField] 
    private float m_distance = 0f;
    [SerializeField] 
    private LayerMask m_layerMask = 7;
    
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
        _animator.SetBool(IsWalk, _mEnemy.velocity != Vector3.zero);
    }
    
    void MoveToNextWayPoint()
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
