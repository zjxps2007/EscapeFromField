using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool(IsOpen, true);
        }
        else
        {
            _animator.SetBool(IsOpen, false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _animator.SetBool(IsOpen, false);
    }
}
