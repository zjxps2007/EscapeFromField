using UnityEngine;

public class M4Custom : MonoBehaviour
{
    [SerializeField]
    private Transform muzzle;
    
    private RaycastHit _hit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DebugRay();
    }

    void DebugRay()
    {
        Debug.DrawRay(muzzle.position, muzzle.forward, Color.yellow);
    }

    void Fire()
    {
        
    }
    
}
