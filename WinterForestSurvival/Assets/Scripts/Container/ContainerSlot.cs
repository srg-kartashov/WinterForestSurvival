using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerSlot : MonoBehaviour
{

    public Image icon;
    public Text nameClot;
    public CurrentContainer curCont;

    public Item item;
    public Button takeButton;

    // Use this for initialization
    void Start()
    {
        curCont = gameObject.transform.parent.GetComponentInParent<CurrentContainer>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        nameClot.text = item.name;
    }

    public void OnButtonTake()
    {
        Inventory.instance.Add(item);
        curCont.currentContainer.Items.Remove(item);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
