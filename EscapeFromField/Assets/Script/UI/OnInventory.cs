using UnityEngine;

public class OnInventory : MonoBehaviour
{
    public static bool inventoryActivated = false;

    [SerializeField]
    private GameObject inventoryBase;

    [SerializeField]
    private GameObject slotsParent;

    private Slot[] slots;
    
    
    // Start is called before the first frame update
    void Start()
    {
        slots = slotsParent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
    }

    void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
        }
    }

    void OpenInventory()
    {
        inventoryBase.SetActive(true);
    }

    void CloseInventory()
    {
        inventoryBase.SetActive(false);
    }

    public void AcquireItem(Items _item, int _count = 1)
    {
        if (Items.ItemType.Equipment != _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }
}
