using UnityEngine;

public class Gun : MonoBehaviour
{
    public string gunName;

    public float range;

    public float accuracy;

    public float fireRate;

    public float reloadTime;

    public int damage;

    public int reloadBulletCount;

    public int currentBullentCount;

    public int maxBulletCount;

    public int carryBulletCount;

    public float retroActionForce;
    
    public float retroActionFinesightForce;

    public Vector3 fineSightOriginPos;

    public Animation anim;
    public ParticleSystem muzzleFlash;

    public AudioClip fireSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
