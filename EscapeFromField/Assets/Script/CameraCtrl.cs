using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    private float xMove = 0;
    
    private float yMove = 0;
    
    private float distance = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xMove += Input.GetAxis("Mouse X");
        yMove -= Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(yMove, xMove, 0);
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
        transform.position = player.transform.position - transform.rotation * reverseDistance;
    }
}
