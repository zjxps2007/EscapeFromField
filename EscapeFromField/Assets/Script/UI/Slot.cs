using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Items item;

    public int itemCount;

    public Image itemImage;

    [SerializeField]
    private Text _textCount;

    private Vector3 _originPos;
    private SlotToolTip theSlot;

    private ItemEffectDatabase _itemEffectDatabase;

    [SerializeField]
    private GameObject[] weapons;

    private WeaponManager _weaponManager; 

    private void Awake()
    {
        _itemEffectDatabase = FindObjectOfType<ItemEffectDatabase>();
        _weaponManager = FindObjectOfType<WeaponManager>();
    }

    private void Start()
    {
        _originPos = transform.position;
    }

    void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    
    //아이템 흭득
    public void AddItem(Items _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if (item.itemType != Items.ItemType.Equipment)
        {
            _textCount.text = itemCount.ToString();
        }
        else
        {
            _textCount.text = "0";
        }

        SetColor(1);
    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        _textCount.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }

    void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);
        
        _textCount.text = "0";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                if (item.itemType == Items.ItemType.Equipment)
                {
                    StartCoroutine(_weaponManager.ChangeWeaponCoroutine(item.weaponType, item.itemName));
                    Debug.Log("장착");
                    //창착
                    //무기를 구현 안해서 일단은 아이템 사용만
                }
                else
                {
                    //소모
                    _itemEffectDatabase.UseItem(item);
                    Debug.Log(item.itemName + "을 사용했습니다.");
                    if (item.itemType == Items.ItemType.Used)
                    {
                        SetSlotCount(-1);
                    }
                }
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();
        }
    }

    private void ChangeSlot()
    {
        Items tempItems = item;
        int tempItempCount = itemCount;
        
        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);
        
        if (tempItems != null)
        {
            DragSlot.instance.dragSlot.AddItem(tempItems, tempItempCount);
        }
        else
        {
            DragSlot.instance.dragSlot.ClearSlot();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    //아이템 사용 지연시간
    IEnumerator Drink()
    {
        yield return new WaitForSeconds(1.0f);
        // 불형 변수로 지정해서 변경
    }
}