using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotToolTip : MonoBehaviour
{
    [SerializeField]
    private GameObject go_Bass;

    [SerializeField]
    private Text txt_ItemName;

    [SerializeField] 
    private Text txt_ItemDesc;

    [SerializeField] 
    private Text txt_ItemHowtoUsed;


    public void ShowToolTip(Items _itme)
    {
        go_Bass.SetActive(true);

        txt_ItemName.text = _itme.itemName;
        txt_ItemDesc.text = _itme.itemDesc;

        if (_itme.itemType == Items.ItemType.Equipment)
        {
            txt_ItemHowtoUsed.text = "우클릭 - 장착";
        }
        else if (_itme.itemType == Items.ItemType.Used)
        {
            txt_ItemHowtoUsed.text = "우클릭 - 먹기";
        }
        else
        {
            txt_ItemHowtoUsed.text = "";
        }
    }

    public void HideToolTip()
    {
        go_Bass.SetActive(false);
    }
}
