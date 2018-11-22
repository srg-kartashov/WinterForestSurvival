using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    public GameObject craftUI;
    public GameObject inventoryUI;
    public List<Item> craftItems;
    public GameObject ItemCraftPref;
    public GameObject content;
    private CraftSlot[] _craftSlots;
    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < craftItems.Count; i++)
        {
            //Debug.Log("CraftUI.Start()");
            Instantiate(ItemCraftPref, content.transform);
        }
        _craftSlots = content.GetComponentsInChildren<CraftSlot>();
        for (int i = 0; i < craftItems.Count; i++)
        {
            //Debug.Log("CraftUI.Start()");
            _craftSlots[i].AddCraftItem(craftItems[i]);
        }
        Inventory.instance.onItemChangedCallBack += UpdateUI;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < craftItems.Count; i++)
        {
            if (_craftSlots[i].checkParts() == false)
            {
                _craftSlots[i].createButton.interactable = false;
            }
            else
            {
                _craftSlots[i].createButton.interactable = true;
            }
        }
        Debug.Log("Updating CraftUI");
    }

    public void ClickCraftButton()
    {
        if (inventoryUI.activeSelf)
            inventoryUI.SetActive(false);
        craftUI.SetActive(!craftUI.activeSelf);

    }
}
