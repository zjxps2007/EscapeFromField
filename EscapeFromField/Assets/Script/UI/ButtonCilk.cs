using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonCilk : MonoBehaviour, IPointerClickHandler
{
    private void Awake()
    {
        PlayerCtrl.score = 0;
        PlayerCtrl.cnt = 0;
        OnInventory.inventoryActivated = false;
        DragSlot.instance = DragSlot.instance;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
