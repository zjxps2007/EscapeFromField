using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newItem", menuName = "newItem/item")]
public class Items : ScriptableObject
{
    public string itemName; //아이템 이름
    [TextArea]
    public string itemDesc; //아이템 설명
    
    public Sprite itemImage; //아이템 이미지

    public GameObject itemPrefab; //아이템 프리팹

    public string weaponType; //무기 타입

    public ItemType itemType; //아이템 타입
    
    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ETC
    }
}
