using UnityEngine;
using UnityEngine.EventSystems;

public class CrossInventory : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject inventoryBase;
   
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button ==PointerEventData.InputButton.Left)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            OnInventory.inventoryActivated = !inventoryBase;
            inventoryBase.SetActive(false);
        }
    }
}