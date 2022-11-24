using UnityEngine;
using UnityEngine.UI;

public class ActionCtrl : MonoBehaviour
{
    [SerializeField] 
    private LayerMask layerMask;

    [SerializeField] 
    private Text actionText;

    [SerializeField]
    private OnInventory theInventory;
    
    private readonly float _range = 4.3f;
    
    private bool _pickUp;

    private RaycastHit _hit;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }
    
    // Update is called once per frameTransformDirection
    void Update()
    {
        Action();
        CheckItem();
        DebugRay();
        
    }

    //레이 디버그용 함수
    void DebugRay()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 4.3f, Color.green);
    }
    
    //F키로 상호 작용
    void Action()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckItem();
            Pick();
        }
    }
    
    //레이케스트로 아이템을 확인
    void CheckItem()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0));
        if (Physics.Raycast(ray.origin, ray.direction, out _hit, _range, layerMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * 4.3f, Color.yellow, 5.0f);
            if (_hit.transform.tag == "Item")
            {
                ItemInfo();
            }
        }
        else
        {
            InfoDisappear();
        }
    }
    
    //아이템의 정보를 가져옴
    void ItemInfo()
    {
        _pickUp = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "<color=#FFFFFF>" + _hit.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 </color>" + "<color=#FF00FF>(F)</color>";
    }

    void InfoDisappear()
    {
        _pickUp = false;
        actionText.gameObject.SetActive(false);
    }

    //아이템 획득
    void Pick()
    {
        if (_pickUp)
        {
            if (_hit.transform != null)
            {
                Debug.Log(_hit.transform.GetComponent<ItemPickUp>().item.itemName + "흭득했습니다.");
                theInventory.AcquireItem(_hit.transform.GetComponent<ItemPickUp>().item);
                Destroy(_hit.transform.gameObject);
                InfoDisappear();
            }
        }
    }
}