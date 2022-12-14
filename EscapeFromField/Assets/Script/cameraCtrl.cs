using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField]
    private Transform objectTofollow;
    
    [SerializeField]
    private Transform mainCamera;

    private readonly float followSpeed = 10f;
    private readonly float sensitivity = 100f;
    private readonly float clampAngle = 45f;

    private float xMove;
    private float yMove;

    
    private Vector3 dirNormalized;
    private Vector3 finalDir;
    private float finalDistance;
    
    private readonly float minDistance = 1.0f;
    private readonly float maxDistance = 2.7f;
    private readonly float smoothness = 2000f; //마우스 감도

    // Start is called before the first frame update
    void Start()
    {
        xMove = transform.localRotation.eulerAngles.x;
        yMove = transform.localRotation.eulerAngles.y;

        dirNormalized = mainCamera.localPosition.normalized;
        finalDistance = mainCamera.localPosition.magnitude;
        
        //플레이 할때 커서를 사라지게 해줌
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!OnInventory.inventoryActivated)
        {
            CameraMoving();
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectTofollow.position, followSpeed * Time.deltaTime);
        finalDir = transform.TransformPoint(dirNormalized * maxDistance);

        if (Physics.Linecast(transform.position, finalDir, out var hit))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            finalDistance = maxDistance;
        }

        mainCamera.localPosition = Vector3.Lerp(mainCamera.localPosition, dirNormalized * finalDistance, Time.deltaTime * smoothness);
    }

    void CameraMoving()
    {
        xMove -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        yMove += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        
        //카메라 y좌표 움직임 제한
        xMove = Mathf.Clamp(xMove, -clampAngle, clampAngle);
        
        Quaternion rot = Quaternion.Euler(xMove, yMove, 0);
        transform.rotation = rot;
    }
}