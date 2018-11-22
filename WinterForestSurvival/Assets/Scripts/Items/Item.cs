using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item" )]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public GameObject prefOutHand;
    public List<Item> details;

    public virtual void Use()
    {
        //Use the item
        //Something might happen

        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        
        Inventory.instance.Remove(this);
    }
    
}
