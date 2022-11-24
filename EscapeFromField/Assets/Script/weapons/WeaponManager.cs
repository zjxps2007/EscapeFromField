using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(GunController))]
public class WeaponManager : MonoBehaviour
{
    // 무기 중복 교체 실행 방지
    public static bool isChangeweapon = false;
    
    // 현제 무기와 현제 무기의 애니메이션
    public static Transform currentWeapon;
    public static Animator currentWeaponAnim;
    
    // 무기 교체 딜레이, 무기 교체가 완전히 끝난 시점.
    [SerializeField]
    private float changeWeaponDelayTime;
    [SerializeField]
    private float changeWeaponEndDelayTime;
    
    // 무기 종류들 전부 관리
    private Dictionary<string, Gun> gunDictionary = new Dictionary<string, Gun>();
    private Dictionary<string, Hand> handDictionary = new Dictionary<string, Hand>();

    [SerializeField]
    private GunController theGunController;

    [SerializeField] 
    private HandController theHandController;
    
    [SerializeField]
    private string currentWeaponType;
    
    // 무기 종류들 전부 관리
    [SerializeField]
    private Gun[] _guns;
    [SerializeField]
    private Hand[] _hands;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _guns.Length; i++)
        {
            gunDictionary.Add(_guns[i].gunName, _guns[i]);
        }
        // for (int i = 0; i < _hands.Length; i++)
        // {
        //     handDictionary.Add(_hands[i].handName, _hands[i]);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChangeweapon)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                StartCoroutine(ChangeWeaponCoroutine("HAND", "맨손"));
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                
            }
        }
    }

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeweapon = true;

        yield return new WaitForSeconds(changeWeaponDelayTime);

        CanceIPreWeaponAction();
        //WeaponChange(_type);
    }

    void CanceIPreWeaponAction()
    {
        switch (currentWeaponType)
        {
            case "GUN":
                break;
            case "HAND":
                break;
        }
    }

    void WeaponChange(string _type, string _name)
    {
        if (_type == "GUN")
        {
            theGunController.GunChange(gunDictionary[_name]);
        }
        // else if (expr)
        // {
        //     
        // }
    }
}
