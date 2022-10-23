using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float speed = 1f;

    private Animator anim;

    private Vector3 movDir;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Walk();
        
    }

    void Walk()
    {
        movDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (movDir != Vector3.zero)
        {
            anim.SetBool("IsWalk",true);
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && movDir != Vector3.zero)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
    }

    void Move()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
    }
    
    
}
