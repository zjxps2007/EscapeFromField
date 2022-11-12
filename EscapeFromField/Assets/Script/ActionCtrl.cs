using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ActionCtrl : MonoBehaviour
{ 
    private float range = 3;

    private bool pickUp = false;

    private RaycastHit hit;

    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private Text actionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckItem();
            Pick();
        }
    }

    void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range, _layerMask))
        {
            if (hit.transform.tag == "Item")
            {
             ItemInfo();   
            }
        }
        else
        {
            InfoDisappear();
        }
    }

    void ItemInfo()
    {
        pickUp = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hit.transform.GetComponent<ItemPickUp>().item.itemName + "흭득 " + "<color=rad>" + "(F)" + "</color>";
    }

    void InfoDisappear()
    {
        pickUp = false;
        actionText.gameObject.SetActive(false);
    }

    void Pick()
    {
        if (pickUp)
        {
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.GetComponent<ItemPickUp>().item.itemName + "흭득했습니다.");
                Destroy(hit.transform.gameObject);
                InfoDisappear();
            }
        }
    }
}
