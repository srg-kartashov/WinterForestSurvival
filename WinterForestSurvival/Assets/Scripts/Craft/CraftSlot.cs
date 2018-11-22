using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{

    public Image icon;
    public Text nameSlot;
    public GameObject parts;

    public Item craftItem;
    public Image PartPref;
    public Button createButton;


    public bool checkParts()
    {

        int count = craftItem.details.Count;
        for (int i = 0; i < Inventory.instance.items.Count; i++)
            for (int j = 0; j < craftItem.details.Count; j++)
            {
                if (craftItem.details[j].Equals(Inventory.instance.items[i]))
                {
                    count--;
                    break;
                }
            }
        return count <= 0;
    }

    public void OnCreateButton()
    {
        if (checkParts())
        {
            #region Старое решение
            //int c = 0;
            //int count = craftItem.details.Count;
            //Debug.Log(count);
            //for (int i = 0; i < Inventory.instance.items.Count; i++)
            //    for (int j = c; j < craftItem.details.Count; j++)
            //    {
            //        if (craftItem.details[j].Equals(Inventory.instance.items[i]))
            //        {

            //            Inventory.instance.Remove(Inventory.instance.items[i]);
            //            c++;
            //            count--;
            //            if (count <= 0)


            //                Debug.Log(count);
            //            break;


            //        }
            //    }
            #endregion 
            for (int i = 0;i<craftItem.details.Count;i++)
            {
                Inventory.instance.Remove(craftItem.details[i]);
            }
        }
        Inventory.instance.Add(craftItem);
    }

    public void AddCraftItem(Item newItem)
    {
        craftItem = newItem;
        icon.sprite = craftItem.icon;
        nameSlot.text = craftItem.name;
        for (int i = 0; i < craftItem.details.Count; i++)
        {
            PartPref.sprite = craftItem.details[i].icon;
            Instantiate(PartPref, parts.transform);


        }


    }
}