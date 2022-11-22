using UnityEngine;

public class Fire : MonoBehaviour
{
    private Vector3 aimVec;

    [SerializeField] private GameObject firePos;
    [SerializeField] private GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aimVec = (Camera.main.transform.position - firePos.transform.position) + (Camera.main.transform.forward * 50f);
        firePos.transform.rotation = Quaternion.LookRotation(aimVec);

        if (!OnInventory.inventoryActivated)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, firePos.transform.position, firePos.transform.rotation);
            }
        }
    }
}
