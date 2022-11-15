using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Items item;

    public int itemCount;

    public Image itemImage;

    [SerializeField]
    private Text _textCount;
    
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
}
