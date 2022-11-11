using System;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float _xMove = 0;

    private float _yMove = 0;

    private float distance = 1;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        _xMove += Input.GetAxis("Mouse X");
        _yMove -= Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(_yMove, _xMove, 0);
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
        transform.position = player.transform.position - transform.rotation * reverseDistance;
    }
}