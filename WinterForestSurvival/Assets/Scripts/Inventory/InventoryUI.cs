using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;

    public GameObject inventoryUI;
    public GameObject craftUI;
    Inventory inventory;
    InventorySlot[] slots;
    // Use this for initialization
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }

    public void ClickInventoryButton()
    {
        if (craftUI.activeSelf)
            craftUI.SetActive(false);
        if (inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);

        }
        else
        {
            UpdateUI();
            inventoryUI.SetActive(true);
            inventoryUI.GetComponent<AudioSource>().Play();
        }


    }
}
