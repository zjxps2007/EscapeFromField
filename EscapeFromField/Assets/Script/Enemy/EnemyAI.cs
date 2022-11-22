using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent m_enemy = null;

    private Animator _animator;

    [SerializeField] 
    private Transform[] m_tfWayPoint = null;

    private int m_count = 0;

    private void Awake()
    {
        m_enemy = GetComponent<NavMeshAgent>();
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
        _animator.SetBool("IsWalk", m_enemy.velocity != Vector3.zero);
    }
    
    void MoveToNextWayPoint()
    {
        if (m_enemy.velocity == Vector3.zero)
        {
            m_enemy.SetDestination(m_tfWayPoint[m_count++].position);

            if (m_count >= m_tfWayPoint.Length)
            {
                m_count = 0;
            }
        }
    }
}
